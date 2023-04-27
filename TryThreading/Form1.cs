using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

    public Form1()
    {
      InitializeComponent();
      cachedImage = new Bitmap(pictureBox1.Image);
    }

    private void btn_reset_Click(object sender, EventArgs e)
    {
      if (cachedImage != null)
      {
        pictureBox1.Image = cachedImage;
      }
      else
      {
        MessageBox.Show("Could not reset image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btn_normal_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;

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
      var buffer = new Bitmap(pictureBox1.Image);

      var counter = 0;
      foreach (var map in maps) 
      {
        buffer = UpdateBuffer(original, buffer, map);        

        ++counter;
        var percent = (int)(((double)counter / maps.Count) * 100);
        lbl_executionTime_normal_value.Text = percent + "%";
        lbl_executionTime_normal_value.Refresh();
      }

      pictureBox1.Image = buffer;
    }

    private Bitmap UpdateBuffer(Bitmap original, Bitmap buffer, KeyValuePair<Color, Color> map)
    {
      for (int x = 0; x < buffer.Width; x++)
      {
        for (int y = 0; y < buffer.Height; y++)
        {
          var px = original.GetPixel(x, y);
          if ((px.R != map.Key.R) ||
              (px.G != map.Key.G) ||
              (px.B != map.Key.B))
          {
            continue;
          }
          else
          {
            buffer.SetPixel(x, y, map.Value);
          }
        }
      }

      return buffer;
    }

    private void PerformUpdates_Threaded()
    {
      //AL.
      //TODO

    }
  }
}
