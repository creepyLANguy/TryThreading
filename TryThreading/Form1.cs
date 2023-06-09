﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
      
      UpdateSpeedDiffLabel();
    }

    private async void btn_threaded_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      
      ResetImage();
      
      repaintedBuffers.Clear();

      var watch = new System.Diagnostics.Stopwatch();
      watch.Start();

      await PerformUpdates_ThreadedAsync();

      watch.Stop();
      Cursor.Current = DefaultCursor;

      lbl_executionTime_threaded_value.Text = watch.ElapsedMilliseconds + " ms";

      UpdateSpeedDiffLabel();
    }

    private void PerformUpdates_Normal()
    {
      var counter = 0;
      foreach (var map in maps)
      {
        GenerateRepaintedBuffer(map);

        ++counter;
        var percent = (int)(((double)counter / maps.Count) * 100);
        lbl_executionTime_normal_value.Text = percent + "%";
        lbl_executionTime_normal_value.Refresh();
      }

      DrawRepaintedBuffersToPictureBox();
    }

    private async Task PerformUpdates_ThreadedAsync()
    {
      List<Task> tasks = new List<Task>();

      foreach (var map in maps)
      {
        tasks.Add(Task.Run(() => GenerateRepaintedBuffer(map)));
      }

      await Task.WhenAll(tasks);

      DrawRepaintedBuffersToPictureBox();
    }

    private void DrawRepaintedBuffersToPictureBox()
    {
      var canvas = new Bitmap(cachedImage);

      foreach (var result in repaintedBuffers)
      {
        using (var g = Graphics.FromImage(canvas))
        {
          g.DrawImage(result, 0, 0);
        }
      }

      pictureBox1.Image = canvas;
    }

    private void GenerateRepaintedBuffer(KeyValuePair<Color, Color> map)
    {
      var oldColor = map.Key;
      var newColor = map.Value;

      Bitmap original = null;
      lock (cachedImage)
      {
        original = new Bitmap(cachedImage);
      }

      var repainted = new Bitmap(original.Width, original.Height);

      for (var y = 0; y < original.Height; y++)
      {
        for (var x = 0; x < original.Width; x++)
        {
          var pixel = original.GetPixel(x, y);
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

    private void UpdateSpeedDiffLabel()
    {
      if (lbl_executionTime_normal_value == lbl_executionTime_threaded_value)
      {
        return;
      }
      if (lbl_executionTime_normal_value.Text == "-" || lbl_executionTime_threaded_value.Text == "-")
      {
        return;
      }
      
      var speedNormal = double.Parse(lbl_executionTime_normal_value.Text.Substring(0, lbl_executionTime_normal_value.Text.IndexOf("ms")).Trim());
      var speedThreaded = double.Parse(lbl_executionTime_threaded_value.Text.Substring(0, lbl_executionTime_threaded_value.Text.IndexOf("ms")).Trim());;
      var diff = (1 - (speedThreaded / speedNormal)) * 100;
      lbl_diff_value.Text = Math.Round(diff, 2) + "%";
    }
  }
}
