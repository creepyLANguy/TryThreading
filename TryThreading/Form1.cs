using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TryThreading
{
  public partial class Form1 : Form
  {
    static Bitmap cachedImage = null;

    static readonly Color TrueGreen = Color.FromArgb(0, 255, 0);
    readonly Dictionary<Color, Color> maps = new Dictionary<Color, Color>()
    {
      { Color.Red,      TrueGreen     },
      { TrueGreen,      Color.Blue    },
      { Color.Blue,     Color.Red     },
      { Color.Cyan,     Color.Magenta },
      { Color.Magenta,  Color.Yellow  },
      { Color.Yellow,   Color.Cyan    },
      { Color.Black,    Color.White   },
      { Color.White,    Color.Black   }
    };

    static List<Bitmap> repaintedBuffers = new List<Bitmap>();

    public Form1()
    {
      InitializeComponent();
      cachedImage = new Bitmap(pictureBox1.Image);
    }

    private void btn_reset_Click(object sender, EventArgs e)
    {
      ResetImage();
    }

    private void btn_normal_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;

      ResetImage();
      
      repaintedBuffers.Clear();

      var watch = new System.Diagnostics.Stopwatch();
      watch.Start();

      PerformUpdates_Normal();

      watch.Stop();
      Cursor.Current = DefaultCursor;

      lbl_executionTime_normal_value.Text = watch.ElapsedMilliseconds + " ms";
    }

    private void btn_threaded_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      
      ResetImage();
      
      repaintedBuffers.Clear();

      var watch = new System.Diagnostics.Stopwatch();
      watch.Start();

      PerformUpdates_Threaded();

      watch.Stop();
      Cursor.Current = DefaultCursor;

      lbl_executionTime_threaded_value.Text = watch.ElapsedMilliseconds + " ms";
    }

    private void PerformUpdates_Normal()
    {
      var original = new Bitmap(pictureBox1.Image);

      var counter = 0;
      foreach (var map in maps)
      {
        GenerateRepaintedBuffer(original, 0, original.Height, map.Key, map.Value);

        ++counter;
        var percent = (int)(((double)counter / maps.Count) * 100);
        lbl_executionTime_normal_value.Text = percent + "%";
        lbl_executionTime_normal_value.Refresh();
      }

      foreach (var result in repaintedBuffers)
      {
        using (var g = Graphics.FromImage(original))
        {
          g.DrawImage(result, 0, 0);
        }
      }

      pictureBox1.Image = original;
    }

    private void PerformUpdates_Threaded()
    {
      //AL.
      //TODO - actually make this threaded. 

      var original = new Bitmap(pictureBox1.Image);     

      var counter = 0;
      foreach (var map in maps)
      {
        GenerateRepaintedBuffer(original, 0, original.Height, map.Key, map.Value);

        ++counter;
        var percent = (int)(((double)counter / maps.Count) * 100);
        lbl_executionTime_threaded_value.Text = percent + "%";
        lbl_executionTime_threaded_value.Refresh();
      }
      
      foreach (var result in repaintedBuffers)
      {
        using (var g = Graphics.FromImage(original))
        {
          g.DrawImage(result, 0, 0);
        }
      }

      pictureBox1.Image = original;
    }

    public static void GenerateRepaintedBuffer(Bitmap buffer, int startY, int endY, Color oldColor, Color newColor)
    {
      var width = buffer.Width;
      var height = buffer.Height;

      var repainted = new Bitmap(width, height);

      for (var y = startY; y < endY; y++)
      {
        for (var x = 0; x < width; x++)
        {
          var pixel = buffer.GetPixel(x, y);
          if (pixel.R != oldColor.R || pixel.G != oldColor.G || pixel.B != oldColor.B)
          {
            continue;
          }
          else
          {
            repainted.SetPixel(x, y, newColor);
          }
        }
      }
      lock (repaintedBuffers)
      {
        repaintedBuffers.Add(repainted);
      }      
    }

    private void ResetImage()
    {
      if (cachedImage != null)
      {
        pictureBox1.Image = cachedImage;
        pictureBox1.Refresh();
      }
      else
      {
        MessageBox.Show("Could not reset image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
