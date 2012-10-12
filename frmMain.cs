using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace Project2_Random
{
	public partial class frmMain : Form
	{
		int[] ProgramGenSeq1;
		int[] ProgramGenSeq2;
		int[] ProgramGenSeq3;
		int[] TableGenSeq1;
		int[] TableGenSeq2;
		int[] TableGenSeq3;
		int[] ManualSeq;
		int bufferPos = 0;

		List<string> StatHeaderColumn = new List<string>()
			{"Mean",
			 "Variance",
			 "ChiSquare",
			 "MonteCarlo",
			 "CompressRat",
			 "ExtremumCriterion"};

		public frmMain()
		{
			Screen screen = Screen.PrimaryScreen;
			if (screen.WorkingArea.Width <= 1024)
				this.WindowState = FormWindowState.Maximized;
			InitializeComponent();
		}

		/**
	 * Returns the area under the left hand tail (from 0 to x)
	 * of the Chi square probability density function with
	 * v degrees of freedom.
	 **/
		/// <summary>
		/// Returns the chi-square function (left hand tail).
		/// </summary>
		/// <param name="df">degrees of freedom</param>
		/// <param name="x">double value</param>
		/// <returns></returns>
		public static double chisq(double df, double x)
		{
			if (x < 0.0 || df < 1.0) return 0.0;

			return alglib.incompletegamma(df / 2.0, x / 2.0);
		}

		private void GetMeanVariance(int[] RandomNumberAr, out double Mean, out double Variance)
		{
			double Sum = 0;
			Array.ForEach(RandomNumberAr, X => Sum += X);
			Sum /= RandomNumberAr.Length;
			Mean = Sum;

			double Dif = 0;
			Array.ForEach(RandomNumberAr, X => Dif += (X - Sum) * (X - Sum));
			Variance = Math.Sqrt(Dif / RandomNumberAr.Length);
		}

		private double ChiSquareCriterion(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			int D = (MaxBorder - MinBorder + 1);
			int N = RandomNumberAr.Length;
			double PiTheor = 1.0 / D;
			double[] PiEmp = new double[D];

			int[] NumberCount = new int[D];
			foreach (int X in RandomNumberAr)
				NumberCount[X - MinBorder]++;

			for (int i = 0; i < D; i++)
				PiEmp[i] = (double)NumberCount[i] / N;

			double Result = 0;
			for (int i = 0; i < D; i++)
				Result += (PiTheor - PiEmp[i]) * (PiTheor - PiEmp[i]) / PiTheor;
			Result *= N;

			return chisq(Result, MaxBorder - MinBorder);
		}

		private double Entropy(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			int[] NumberCount = new int[MaxBorder - MinBorder + 1];
			foreach (int X in RandomNumberAr)
				NumberCount[X - MinBorder]++;

			double P;
			double Result = 0;
			for (int i = 0; i < MaxBorder - MinBorder + 1; i++)
			{
				P = (double)NumberCount[i] / RandomNumberAr.Length;
				if (P > 0.0)
					Result += P * Math.Log(1 / P, 2);
			}
			return Result;
		}

		private double MonteCarloTest(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			int LeftCount = 0;
			int RightCount = 0;
			double Middle = (MaxBorder + MinBorder) / 2.0;
			for (int i = 0; i < RandomNumberAr.Length; i++)
				if (RandomNumberAr[i] < Middle)
					LeftCount++;
				else
					if (RandomNumberAr[i] > Middle)
						RightCount++;
					else
					{
						LeftCount++;
						RightCount++;
					}
			return (double)LeftCount / RightCount;
		}

		private double MonteCarloPiTest(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			int InCircleCount = 0;
			int OutCircleCount = 0;
			int R2;
			int Radius2 = (MaxBorder - MinBorder) * (MaxBorder - MinBorder);
			for (int i = 0; i < RandomNumberAr.Length - 1; i += 2)
			{
				R2 = (RandomNumberAr[i] - MinBorder) * (RandomNumberAr[i] - MinBorder) +
					 (RandomNumberAr[i + 1] - MinBorder) * (RandomNumberAr[i + 1] - MinBorder);
				if (R2 < Radius2)
					InCircleCount++;
				else
					if (R2 > Radius2)
						OutCircleCount++;
					else
					{
						InCircleCount++;
						OutCircleCount++;
					}
			}
			double PiEmp = (double)InCircleCount / (InCircleCount + OutCircleCount) * 4.0;
			return Math.Abs(Math.PI - PiEmp) / Math.PI;
		}

		private void NeigbourDifTest(int[] RandomNumberAr, out double Mean, out double Variance)
		{
			double M = 0;
			double V = 0;
			double[] Difs = new double[RandomNumberAr.Length];
			for (int i = 0; i < RandomNumberAr.Length - 1; i++)
				Difs[i] = Math.Abs(RandomNumberAr[i + 1] - RandomNumberAr[i]);
			Difs[RandomNumberAr.Length - 1] = RandomNumberAr[0] - RandomNumberAr[RandomNumberAr.Length - 1];

			Array.ForEach(Difs, X => M += X);
			M /= Difs.Length;
			Mean = M;
			Array.ForEach(Difs, X => V += (X - M) * (X - M));
			Variance = Math.Sqrt(V / Difs.Length);
		}

		private double[] Normalize(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			double[] Result = new double[RandomNumberAr.Length];
			for (int i = 0; i < RandomNumberAr.Length; i++)
				Result[i] = (double)RandomNumberAr[i] / (MaxBorder - MinBorder + 1);
			return Result;
		}

		void mMultiply(double[] A, double[] B, double[] C, int m)
		{
			int i, j, k;
			double s;
			for (i = 0; i < m; i++)
			{
				for (j = 0; j < m; j++)
				{
					s = 0.0;
					for (k = 0; k < m; k++)
					{
						s += A[i * m + k] * B[k * m + j];
						C[i * m + j] = s;
					}
				}
			}
		}

		void mPower(double[] A, int eA, double[] V, ref int eV, int m, int n)
		{
			double[] B;
			int eB, i;

			/*
			 * n == 1: first power just returns A.
			 */
			if (n == 1)
			{
				for (i = 0; i < m * m; i++)
				{
					V[i] = A[i]; eV = eA;
				}
				return;
			}

			/*
			 * This is a recursive call.  Either n/2 will equal 1 (and the line
			 * above will return and the recursion will terminate) or it won't
			 * and we will cumulate the product.
			 */
			mPower(A, eA, V, ref eV, m, n / 2);
			B = new double[m * m];
			mMultiply(V, V, B, m);
			eB = 2 * eV;
			if (n % 2 == 0)
			{
				for (i = 0; i < m * m; i++)
				{
					V[i] = B[i];
				}
				eV = eB;
			}
			else
			{
				mMultiply(A, B, V, m);
				eV = eA + eB;
			}

			/*
			 * Rescale as needed to avoid overflow.
			 */
			if (V[(m / 2) * m + (m / 2)] > 1e140)
			{
				for (i = 0; i < m * m; i++)
				{
					V[i] = V[i] * 1e-140;
				}
				eV += 140;
			}
		}

		double SpectralTest(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			int N = RandomNumberAr.Length;
			double T = Math.Sqrt(2.995732274 * N);
			double N0 = 0.95 * N / 2.0;
			double N1 = 0;
			double Interval = (double)(MinBorder + MaxBorder);
			double Mid = Interval / 2.0;

			double[] a = new double[N];
			for (int i = 0; i < N; i++)
				a[i] = RandomNumberAr[i] / Mid - 1.0;
			//a = Normalize(RandomNumberAr, MinBorder, MaxBorder);
			alglib.complex[] f;
			alglib.fftr1d(a, out f);
			for (int i = 0; i < N / 2; i++)
			{
				if (Math.Sqrt(f[i].x * f[i].x + f[i].y * f[i].y) < T)
					N1++;
			}
			double max = double.NegativeInfinity, min = double.PositiveInfinity;
			foreach (double x in a)
			{
				if (x > max)
					max = x;
				if (x < min)
					min = x;
			}

			double Pv = alglib.errorfunctionc(Math.Abs(N1 - N0) / (0.02375 * N)); //Math.Sqrt(0.02375 * N));
			return Pv;
		}

		double ValdaVolfovicCriterion(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			double Mean = 0;
			foreach (int X in RandomNumberAr)
				Mean += X;
			Mean /= RandomNumberAr.Length;

			int n1 = 0, n2 = 0;
			if (RandomNumberAr[0] >= Mean)
				n1++;
			else
				n2++;
			for (int i = 1; i < RandomNumberAr.Length; i++)
			{
				if (RandomNumberAr[i - 1] >= Mean)
				{
					if (RandomNumberAr[i] < Mean)
						n2++;
				}
				else
				{
					if (RandomNumberAr[i] >= Mean)
						n1++;
				}
			}

			double ENs = (double)(2 * (n1 + n2)) / (n1 * n2) + 1;
			double DNs = (double)(2 * n1 * n2 * (2 * n1 * n2 - (n1 + n2))) /
				((n1 + n2) * (n1 + n2) * (n1 + n2 - 1));

			double P = (RandomNumberAr.Length - ENs) / Math.Sqrt(DNs);
			return P;
		}

		double ExtremumCriterion(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			int LocalExtremumCount = 0;
			for (int i = 1; i < RandomNumberAr.Length - 1; i++)
				if (RandomNumberAr[i] - RandomNumberAr[i - 1] > 0)
				{
					if (RandomNumberAr[i] - RandomNumberAr[i + 1] >= 0)
						LocalExtremumCount++;
				}
				else
				{
					if (RandomNumberAr[i] - RandomNumberAr[i + 1] < 0)
						LocalExtremumCount++;
				}

			double ET = 2.0 / 3.0 * RandomNumberAr.Length;
			double DT = 8.0 / 45.0 * RandomNumberAr.Length;

			double N = (LocalExtremumCount - ET) / Math.Sqrt(DT);

			double alpha = 0.05;
			double F = alglib.invnormaldistribution(alpha / 2);

			return N;
		}

		/* Marsaglia's definition is K = 1 - p.  I convert it to p, as p is
		 what we want in dieharder. */
		double p_ks_new(int n, double d)
		{
			int k, m, i, j, g, eH, eQ;
			double h, s;
			double[] H, Q;

			/*
			 * If ks_test = 2, we always execute the following code and work to
			 * convergence.
			 */
			k = (int)(n * d) + 1;
			m = 2 * k - 1;
			h = k - n * d;
			H = new double[m * m];
			Q = new double[m * m];
			for (i = 0; i < m; i++)
			{
				for (j = 0; j < m; j++)
				{
					if (i - j + 1 < 0)
					{
						H[i * m + j] = 0;
					}
					else
					{
						H[i * m + j] = 1;
					}
				}
			}

			for (i = 0; i < m; i++)
			{
				H[i * m] -= Math.Pow(h, i + 1);
				H[(m - 1) * m + i] -= Math.Pow(h, (m - i));
			}
			H[(m - 1) * m] += (2 * h - 1 > 0 ? Math.Pow(2 * h - 1, m) : 0);
			for (i = 0; i < m; i++)
			{
				for (j = 0; j < m; j++)
				{
					if (i - j + 1 > 0)
					{
						for (g = 1; g <= i - j + 1; g++)
						{
							H[i * m + j] /= g;
						}
					}
				}
			}
			eH = 0;
			eQ = 0;
			mPower(H, eH, Q, ref eQ, m, n);
			s = Q[(k - 1) * m + k - 1];
			for (i = 1; i <= n; i++)
			{
				s = s * i / n;
				if (s < 1e-140)
				{
					s *= 1e140;
					eQ -= 140;
				}
			}

			s *= Math.Pow(10.0, eQ);
			s = 1.0 - s;
			return s;

		}

		private double KTest(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			double[] normAr = Normalize(RandomNumberAr, MinBorder, MaxBorder);
			Array.Sort(normAr);
			double y, d;
			double dmax = 0.0;
			for (int i = 0; i < normAr.Length; i++)
			{
				y = (double)i / normAr.Length;
				d = Math.Max(normAr[i] - y, (1.0 / normAr.Length) - (normAr[i] - y));
				if (d > dmax)
					dmax = d;
			}
			return p_ks_new(normAr.Length, dmax);
		}

		private double CompressionTest(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			FileInfo tempFile = new System.IO.FileInfo(@"..\..\temp.bin");
			StreamWriter writer = tempFile.AppendText();
			foreach (int number in RandomNumberAr)
				writer.Write((char)number);
			writer.Close();

			ProcessStartInfo psi = new ProcessStartInfo(@"..\..\lzma.exe");
			psi.RedirectStandardOutput = true;
			psi.UseShellExecute = false;
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			psi.CreateNoWindow = true;
			psi.StandardOutputEncoding = Encoding.GetEncoding(866);
			psi.Arguments = @"e ""..\..\temp.bin"" ""..\..\temp.lzma"" -d16 -lc0";
			Process task = Process.Start(psi);
			while (!task.HasExited)
				Thread.Sleep(100);

			FileInfo compressedTempFile = new System.IO.FileInfo(@"..\..\temp.lzma");

			double ratio = (double)compressedTempFile.Length / tempFile.Length;

			tempFile.Delete();
			compressedTempFile.Delete();

			return ratio;
		}

		private List<double> TestSeq(int[] RandomNumberAr, int MinBorder, int MaxBorder)
		{
			List<double> Result = new List<double>();

			double Mean, Variance, ChiSquare, MonteCarlo;
			GetMeanVariance(RandomNumberAr, out Mean, out Variance);
			ChiSquare = ChiSquareCriterion(RandomNumberAr, MinBorder, MaxBorder);
			MonteCarlo = MonteCarloPiTest(RandomNumberAr, MinBorder, MaxBorder);

			Result.Add(Mean);
			Result.Add(Variance);
			Result.Add(ChiSquare);
			Result.Add(MonteCarlo);
			Result.Add(CompressionTest(RandomNumberAr, MinBorder, MaxBorder));
			Result.Add(ExtremumCriterion(RandomNumberAr, MinBorder, MaxBorder));

			return Result;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			StreamReader reader = new StreamReader(@"..\..\RandomTable.txt");
			int readerLength = (int)reader.BaseStream.Length;
			char[] buffer = new char[readerLength];
			reader.Read(buffer, 0, readerLength);
			reader.Close();

			Random rand = new Random();
			int count = (int)udNumberCount.Value;
			dgvProgramGen.Rows.Clear();
			dgvProgramGen.Rows.Add(count);
			dgvTableGen.Rows.Clear();
			dgvTableGen.Rows.Add(count);
			ProgramGenSeq1 = new int[count];
			ProgramGenSeq2 = new int[count];
			ProgramGenSeq3 = new int[count];
			TableGenSeq1 = new int[count];
			TableGenSeq2 = new int[count];
			TableGenSeq3 = new int[count];
			for (int i = 0; i < count; i++)
			{
				ProgramGenSeq1[i] = rand.Next(10);
				ProgramGenSeq2[i] = rand.Next(100);
				ProgramGenSeq3[i] = rand.Next(1000);

				string str = "";
				str += buffer[bufferPos];
				bufferPos = (bufferPos + 1) % readerLength;
				TableGenSeq1[i] = Convert.ToInt32(str);

				str = "";
				str += buffer[bufferPos];
				bufferPos = (bufferPos + 1) % readerLength;
				str += buffer[bufferPos];
				bufferPos = (bufferPos + 1) % readerLength;
				TableGenSeq2[i] = Convert.ToInt32(str);

				str = "";
				str += buffer[bufferPos];
				bufferPos = (bufferPos + 1) % readerLength;
				str += buffer[bufferPos];
				bufferPos = (bufferPos + 1) % readerLength;
				str += buffer[bufferPos];
				bufferPos = (bufferPos + 1) % readerLength;
				TableGenSeq3[i] = Convert.ToInt32(str);

				dgvProgramGen[0, i].Value = ProgramGenSeq1[i];
				dgvProgramGen[1, i].Value = ProgramGenSeq2[i];
				dgvProgramGen[2, i].Value = ProgramGenSeq3[i];

				dgvTableGen[0, i].Value = TableGenSeq1[i];
				dgvTableGen[1, i].Value = TableGenSeq2[i];
				dgvTableGen[2, i].Value = TableGenSeq3[i];
			}
			List<double> programGenSeq1Stat = TestSeq(ProgramGenSeq1, 0, 9);
			List<double> programGenSeq2Stat = TestSeq(ProgramGenSeq2, 0, 99);
			List<double> programGenSeq3Stat = TestSeq(ProgramGenSeq3, 0, 999);
			List<double> tableGenSeq1Stat = TestSeq(TableGenSeq1, 0, 9);
			List<double> tableGenSeq2Stat = TestSeq(TableGenSeq2, 0, 99);
			List<double> tableGenSeq3Stat = TestSeq(TableGenSeq3, 0, 999);
			int statLineCount = programGenSeq1Stat.Count;

			for (int i = 0; i < statLineCount; i++)
			{
				dgvResult1.Rows[i].HeaderCell.Value = StatHeaderColumn[i];

				dgvResult1[0, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], programGenSeq1Stat[i]);
				dgvResult1[1, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], programGenSeq2Stat[i]);
				dgvResult1[2, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], programGenSeq3Stat[i]);

				dgvResult1[0, i].Value = programGenSeq1Stat[i].ToString("N2");
				dgvResult1[1, i].Value = programGenSeq2Stat[i].ToString("N2");
				dgvResult1[2, i].Value = programGenSeq3Stat[i].ToString("N2");

				dgvResult2[0, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], tableGenSeq1Stat[i]);
				dgvResult2[1, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], tableGenSeq2Stat[i]);
				dgvResult2[2, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], tableGenSeq3Stat[i]);

				dgvResult2[0, i].Value = tableGenSeq1Stat[i].ToString("N2");
				dgvResult2[1, i].Value = tableGenSeq2Stat[i].ToString("N2");
				dgvResult2[2, i].Value = tableGenSeq3Stat[i].ToString("N2");
			}
		}

		private Color GetCellColor(string Test, double value)
		{
			switch (Test)
			{
				case "ChiSquare":
					if (value <= 0.05 || value >= 0.95)
						return Color.Red;
					else
						if (value <= 0.1 || value >= 0.9)
							return Color.Yellow;
						else
							return Color.White;
				case "MonteCarlo":
					if (value <= 0.1)
						return Color.White;
					else
						if (value <= 0.2)
							return Color.Yellow;
						else
							return Color.Red;
				case "CompressRat":
					if (value <= 0.1)
						return Color.Red;
					else
						if (value <= 0.6)
							return Color.Yellow;
						else
							return Color.White;
				case "ExtremumCriterion":
					if (Math.Abs(value) >= 5)
						return Color.Red;
					else
						if (Math.Abs(value) >= 2)
							return Color.Yellow;
						else
							return Color.White;
				default:
					return Color.White;
			}
		}

		private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
		{
			if (dgvManualMethod.Rows.Count < (int)udManualMethod.Value + 1)
				dgvManualMethod.Rows.Add((int)udManualMethod.Value - dgvManualMethod.Rows.Count);
			else
				if (dgvManualMethod.Rows.Count > (int)udManualMethod.Value + 1)
				{
					int d = dgvManualMethod.Rows.Count - (int)udManualMethod.Value;
					for (int i = 0; i < d; i++)
						dgvManualMethod.Rows.RemoveAt(dgvManualMethod.Rows.Count - 2);
				}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int count = (int)udManualMethod.Value;
			List<int> temp = new List<int>(dgvManualMethod.Rows.Count);
			for (int i = 0; i < dgvManualMethod.Rows.Count - 1; i++)
				if (dgvManualMethod[0, i].Value.ToString() != "")
					temp.Add(Convert.ToInt32(dgvManualMethod[0, i].Value));
			ManualSeq = temp.ToArray();
			int min = int.MaxValue;
			int max = int.MinValue;
			for (int i = 0; i < ManualSeq.Length; i++)
			{
				if (ManualSeq[i] < min)
					min = ManualSeq[i];
				if (ManualSeq[i] > max)
					max = ManualSeq[i];
			}
			List<double> manualSeqStat = TestSeq(ManualSeq, min, max);
			int statLineCount = manualSeqStat.Count;
			for (int i = 0; i < statLineCount; i++)
			{
				dgvResult3[0, i].Style.BackColor = GetCellColor(StatHeaderColumn[i], manualSeqStat[i]);
				dgvResult3[0, i].Value = manualSeqStat[i].ToString("N2");
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			/*var rand = new Random();
			var strs = new string[5000];
			for (int i = 0; i < 5000; i++)
				strs[i] = rand.Next(10).ToString();
			File.WriteAllLines("RandomTable0.txt", strs);

			rand = new Random();
			strs = new string[5000];
			for (int i = 0; i < 5000; i++)
				strs[i] = rand.Next(100).ToString();
			File.WriteAllLines("RandomTable00.txt", strs);

			rand = new Random();
			strs = new string[5000];
			for (int i = 0; i < 5000; i++)
				strs[i] = rand.Next(1000).ToString();
			File.WriteAllLines("RandomTable000.txt", strs);*/


			int statLineCount = StatHeaderColumn.Count;
			dgvResult1.Rows.Add(statLineCount);
			dgvResult2.Rows.Add(statLineCount);
			dgvResult3.Rows.Add(statLineCount);

			string[] fileNames = Directory.GetFiles(@"..\..", "*.txt", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < fileNames.Length; i++)
				fileNames[i] = Path.GetFileName(fileNames[i]);
			cmbFiles.Items.AddRange(fileNames);
			cmbFiles.SelectedIndex = 0;

			for (int i = 0; i < statLineCount; i++)
				dgvResult1.Rows[i].HeaderCell.Value = StatHeaderColumn[i];
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			StreamReader reader = new StreamReader(@"..\..\" + (string)cmbFiles.SelectedItem);
			int count = 0;
			dgvManualMethod.Rows.Clear();
			while (!reader.EndOfStream)
			{
				dgvManualMethod.Rows.Add(reader.ReadLine());
				count++;
			}
			udManualMethod.Value = count;
			button2_Click(sender, e);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			dgvManualMethod.Rows.Clear();
		}
	}
}
