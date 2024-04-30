// <auto-generated />
#pragma warning disable 1570, 1591

using System;
using Microsoft.ML.Probabilistic;
using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Factors;
using Microsoft.ML.Probabilistic.Collections;

namespace Models
{
	/// <summary>
	/// Generated algorithm for performing inference.
	/// </summary>
	/// <remarks>
	/// If you wish to use this class directly, you must perform the following steps:
	/// 1) Create an instance of the class.
	/// 2) Set the value of any externally-set fields e.g. data, priors.
	/// 3) Call the Execute(numberOfIterations) method.
	/// 4) Use the XXXMarginal() methods to retrieve posterior marginals for different variables.
	/// 
	/// Generated by Infer.NET 0.4.2403.801 at 9:51 on 30 апреля 2024 г..
	/// </remarks>
	public partial class Model_EP : IGeneratedAlgorithm
	{
		#region Fields
		/// <summary>True if Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1 has executed. Set this to false to force re-execution of Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1</summary>
		public bool Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone;
		/// <summary>True if Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1 has executed. Set this to false to force re-execution of Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1</summary>
		public bool Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone;
		/// <summary>True if Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1 has performed initialisation. Set this to false to force re-execution of Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1</summary>
		public bool Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isInitialised;
		/// <summary>True if Changed_vint____0 has executed. Set this to false to force re-execution of Changed_vint____0</summary>
		public bool Changed_vint____0_isDone;
		/// <summary>True if Changed_vint__0 has executed. Set this to false to force re-execution of Changed_vint__0</summary>
		public bool Changed_vint__0_isDone;
		/// <summary>True if Changed_vint__0_vint__1_vint0 has executed. Set this to false to force re-execution of Changed_vint__0_vint__1_vint0</summary>
		public bool Changed_vint__0_vint__1_vint0_isDone;
		/// <summary>True if Changed_vint__1 has executed. Set this to false to force re-execution of Changed_vint__1</summary>
		public bool Changed_vint__1_isDone;
		/// <summary>True if Changed_vint0 has executed. Set this to false to force re-execution of Changed_vint0</summary>
		public bool Changed_vint0_isDone;
		/// <summary>True if Changed_vint1 has executed. Set this to false to force re-execution of Changed_vint1</summary>
		public bool Changed_vint1_isDone;
		/// <summary>Field backing the NumberOfIterationsDone property</summary>
		private int numberOfIterationsDone;
		/// <summary>Message to marginal of 'vdouble__0'</summary>
		public DistributionStructArray<Gaussian,double> vdouble__0_marginal_F;
		public DistributionStructArray<Gaussian,double>[] vdouble__2_B;
		/// <summary>Field backing the vint____0 property</summary>
		private int[][] vint____0_field;
		/// <summary>Message to marginal of 'vint____0'</summary>
		public PointMass<int[][]> vint____0_marginal_F;
		/// <summary>Field backing the vint__0 property</summary>
		private int[] vint__0_field;
		/// <summary>Message to marginal of 'vint__0'</summary>
		public PointMass<int[]> vint__0_marginal_F;
		/// <summary>Field backing the vint__1 property</summary>
		private int[] vint__1_field;
		/// <summary>Message to marginal of 'vint__1'</summary>
		public PointMass<int[]> vint__1_marginal_F;
		/// <summary>The constant 'vint__2'</summary>
		public int[] vint__2;
		/// <summary>Message to marginal of 'vint__2'</summary>
		public DistributionRefArray<Discrete,int> vint__2_marginal_F;
		/// <summary>Field backing the vint0 property</summary>
		private int vint0_field;
		/// <summary>Message to marginal of 'vint0'</summary>
		public PointMass<int> vint0_marginal_F;
		/// <summary>Field backing the vint1 property</summary>
		private int vint1_field;
		/// <summary>Message to marginal of 'vint1'</summary>
		public PointMass<int> vint1_marginal_F;
		#endregion

		#region Properties
		/// <summary>The number of iterations done from the initial state</summary>
		public int NumberOfIterationsDone
		{
			get {
				return this.numberOfIterationsDone;
			}
		}

		/// <summary>The externally-specified value of 'vint____0'</summary>
		public int[][] vint____0
		{
			get {
				return this.vint____0_field;
			}
			set {
				if ((value!=null)&&(value.Length!=this.vint0)) {
					throw new ArgumentException(((("Provided array of length "+value.Length)+" when length ")+this.vint0)+" was expected for variable \'vint____0\'");
				}
				this.vint____0_field = value;
				this.numberOfIterationsDone = 0;
				this.Changed_vint____0_isDone = false;
				this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isInitialised = false;
				this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = false;
			}
		}

		/// <summary>The externally-specified value of 'vint__0'</summary>
		public int[] vint__0
		{
			get {
				return this.vint__0_field;
			}
			set {
				if ((value!=null)&&(value.Length!=this.vint0)) {
					throw new ArgumentException(((("Provided array of length "+value.Length)+" when length ")+this.vint0)+" was expected for variable \'vint__0\'");
				}
				this.vint__0_field = value;
				this.numberOfIterationsDone = 0;
				this.Changed_vint__0_isDone = false;
				this.Changed_vint__0_vint__1_vint0_isDone = false;
				this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone = false;
				this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = false;
			}
		}

		/// <summary>The externally-specified value of 'vint__1'</summary>
		public int[] vint__1
		{
			get {
				return this.vint__1_field;
			}
			set {
				if ((value!=null)&&(value.Length!=this.vint0)) {
					throw new ArgumentException(((("Provided array of length "+value.Length)+" when length ")+this.vint0)+" was expected for variable \'vint__1\'");
				}
				this.vint__1_field = value;
				this.numberOfIterationsDone = 0;
				this.Changed_vint__1_isDone = false;
				this.Changed_vint__0_vint__1_vint0_isDone = false;
				this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone = false;
				this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = false;
			}
		}

		/// <summary>The externally-specified value of 'vint0'</summary>
		public int vint0
		{
			get {
				return this.vint0_field;
			}
			set {
				if (this.vint0_field!=value) {
					this.vint0_field = value;
					this.numberOfIterationsDone = 0;
					this.Changed_vint0_isDone = false;
					this.Changed_vint__0_vint__1_vint0_isDone = false;
					this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone = false;
					this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = false;
				}
			}
		}

		/// <summary>The externally-specified value of 'vint1'</summary>
		public int vint1
		{
			get {
				return this.vint1_field;
			}
			set {
				if (this.vint1_field!=value) {
					this.vint1_field = value;
					this.numberOfIterationsDone = 0;
					this.Changed_vint1_isDone = false;
					this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isInitialised = false;
					this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = false;
				}
			}
		}

		#endregion

		#region Methods
		/// <summary>Computations that depend on the observed value of numberOfIterations and vint____0 and vint__0 and vint__1 and vint0 and vint1</summary>
		/// <param name="numberOfIterations">The number of times to iterate each loop</param>
		private void Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1(int numberOfIterations)
		{
			if (this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone) {
				return ;
			}
			DistributionStructArray<Gaussian,double> vdouble__0_F;
			Gaussian vdouble__0_F_reduced;
			vdouble__0_F_reduced = default(Gaussian);
			// Create array for 'vdouble__0' Forwards messages.
			vdouble__0_F = new DistributionStructArray<Gaussian,double>(this.vint1);
			if (this.vint1>0) {
				// Message to 'vdouble__0' from GaussianFromMeanAndVariance factor
				vdouble__0_F_reduced = GaussianFromMeanAndVarianceOp.SampleAverageConditional(6.0, 9.0);
			}
			for(int index1 = 0; index1<this.vint1; index1++) {
				vdouble__0_F[index1] = vdouble__0_F_reduced;
				vdouble__0_F[index1] = vdouble__0_F_reduced;
			}
			// Create array for 'vdouble__0_marginal' Forwards messages.
			this.vdouble__0_marginal_F = new DistributionStructArray<Gaussian,double>(this.vint1);
			for(int index1 = 0; index1<this.vint1; index1++) {
				this.vdouble__0_marginal_F[index1] = Gaussian.Uniform();
			}
			DistributionRefArray<DistributionStructArray<Gaussian,double>,double[]> vdouble__0_vint____0_F;
			// Create array for 'vdouble__0_vint____0' Forwards messages.
			vdouble__0_vint____0_F = new DistributionRefArray<DistributionStructArray<Gaussian,double>,double[]>(this.vint0);
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__0_vint____0' Forwards messages.
				vdouble__0_vint____0_F[index0] = new DistributionStructArray<Gaussian,double>(this.vint__2[index0]);
				for(int index4 = 0; index4<this.vint__2[index0]; index4++) {
					vdouble__0_vint____0_F[index0][index4] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble__3_B'
			DistributionStructArray<Gaussian,double>[] vdouble__3_B = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__3' Backwards messages.
				vdouble__3_B[index0] = new DistributionStructArray<Gaussian,double>(this.vint__0[index0]);
				for(int _iv2 = 0; _iv2<this.vint__0[index0]; _iv2++) {
					vdouble__3_B[index0][_iv2] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble__4_B'
			DistributionStructArray<Gaussian,double>[] vdouble__4_B = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__4' Backwards messages.
				vdouble__4_B[index0] = new DistributionStructArray<Gaussian,double>(this.vint__1[index0]);
				for(int _iv = 0; _iv<this.vint__1[index0]; _iv++) {
					vdouble__4_B[index0][_iv] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble__3_F'
			DistributionStructArray<Gaussian,double>[] vdouble__3_F = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__3' Forwards messages.
				vdouble__3_F[index0] = new DistributionStructArray<Gaussian,double>(this.vint__0[index0]);
				for(int _iv2 = 0; _iv2<this.vint__0[index0]; _iv2++) {
					vdouble__3_F[index0][_iv2] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble__5_F'
			DistributionStructArray<Gaussian,double>[] vdouble__5_F = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__5' Forwards messages.
				vdouble__5_F[index0] = new DistributionStructArray<Gaussian,double>(this.vint__0[index0]);
				for(int index2 = 0; index2<this.vint__0[index0]; index2++) {
					vdouble__5_F[index0][index2] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble15_F'
			Gaussian[] vdouble15_F = new Gaussian[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				vdouble15_F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble__4_F'
			DistributionStructArray<Gaussian,double>[] vdouble__4_F = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__4' Forwards messages.
				vdouble__4_F[index0] = new DistributionStructArray<Gaussian,double>(this.vint__1[index0]);
				for(int _iv = 0; _iv<this.vint__1[index0]; _iv++) {
					vdouble__4_F[index0][_iv] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble__7_F'
			DistributionStructArray<Gaussian,double>[] vdouble__7_F = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__7' Forwards messages.
				vdouble__7_F[index0] = new DistributionStructArray<Gaussian,double>(this.vint__1[index0]);
				for(int index3 = 0; index3<this.vint__1[index0]; index3++) {
					vdouble__7_F[index0][index3] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble22_F'
			Gaussian[] vdouble22_F = new Gaussian[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				vdouble22_F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble23_F'
			Gaussian[] vdouble23_F = new Gaussian[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				vdouble23_F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble23_B'
			Gaussian[] vdouble23_B = new Gaussian[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				vdouble23_B[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble15_B'
			Gaussian[] vdouble15_B = new Gaussian[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				vdouble15_B[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble__5_use_B'
			DistributionStructArray<Gaussian,double>[] vdouble__5_use_B = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__5_use' Backwards messages.
				vdouble__5_use_B[index0] = new DistributionStructArray<Gaussian,double>(this.vint__0[index0]);
				for(int index2 = 0; index2<this.vint__0[index0]; index2++) {
					vdouble__5_use_B[index0][index2] = Gaussian.Uniform();
				}
			}
			// Create array for replicates of 'vdouble22_B'
			Gaussian[] vdouble22_B = new Gaussian[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				vdouble22_B[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble__7_use_B'
			DistributionStructArray<Gaussian,double>[] vdouble__7_use_B = new DistributionStructArray<Gaussian,double>[this.vint0];
			for(int index0 = 0; index0<this.vint0; index0++) {
				// Create array for 'vdouble__7_use' Backwards messages.
				vdouble__7_use_B[index0] = new DistributionStructArray<Gaussian,double>(this.vint__1[index0]);
				for(int index3 = 0; index3<this.vint__1[index0]; index3++) {
					vdouble__7_use_B[index0][index3] = Gaussian.Uniform();
				}
			}
			for(int iteration = this.numberOfIterationsDone; iteration<numberOfIterations; iteration++) {
				// Message to 'vdouble__0_marginal' from JaggedSubarrayWithMarginal factor
				this.vdouble__0_marginal_F = JaggedSubarrayWithMarginalOp<double>.MarginalAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian,DistributionStructArray<Gaussian,double>>(vdouble__0_F, this.vdouble__2_B, this.vint____0, this.vdouble__0_marginal_F);
				for(int index0 = 0; index0<this.vint0; index0++) {
					// Message to 'vdouble__0_vint____0' from JaggedSubarrayWithMarginal factor
					vdouble__0_vint____0_F[index0] = JaggedSubarrayWithMarginalOp<double>.ItemsAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian,DistributionStructArray<Gaussian,double>>(this.vdouble__2_B[index0], vdouble__0_F, this.vdouble__0_marginal_F, this.vint____0, index0, vdouble__0_vint____0_F[index0]);
					// Message to 'vdouble__4' from Split factor
					vdouble__4_F[index0] = SplitOp<double>.TailAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian>(vdouble__0_vint____0_F[index0], this.vint__0[index0], vdouble__4_F[index0]);
					for(int index3 = 0; index3<this.vint__1[index0]; index3++) {
						// Message to 'vdouble__7' from GaussianFromMeanAndVariance factor
						vdouble__7_F[index0][index3] = GaussianFromMeanAndVarianceOp.SampleAverageConditional(vdouble__4_F[index0][index3], 1.0);
					}
					// Message to 'vdouble22' from Sum factor
					vdouble22_F[index0] = FastSumOp.SumAverageConditional(vdouble__7_F[index0]);
					// Message to 'vdouble__3' from Split factor
					vdouble__3_F[index0] = SplitOp<double>.HeadAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian>(vdouble__0_vint____0_F[index0], this.vint__0[index0], vdouble__3_F[index0]);
					for(int index2 = 0; index2<this.vint__0[index0]; index2++) {
						// Message to 'vdouble__5' from GaussianFromMeanAndVariance factor
						vdouble__5_F[index0][index2] = GaussianFromMeanAndVarianceOp.SampleAverageConditional(vdouble__3_F[index0][index2], 1.0);
					}
					// Message to 'vdouble15' from Sum factor
					vdouble15_F[index0] = FastSumOp.SumAverageConditional(vdouble__5_F[index0]);
					// Message to 'vdouble23' from Difference factor
					vdouble23_F[index0] = DoublePlusOp.AAverageConditional(vdouble15_F[index0], vdouble22_F[index0]);
					// Message to 'vdouble23' from IsPositive factor
					vdouble23_B[index0] = IsPositiveOp_Proper.XAverageConditional(Bernoulli.PointMass(true), vdouble23_F[index0]);
					// Message to 'vdouble22' from Difference factor
					vdouble22_B[index0] = DoublePlusOp.BAverageConditional(vdouble15_F[index0], vdouble23_B[index0]);
					// Message to 'vdouble__7_use' from Sum factor
					vdouble__7_use_B[index0] = FastSumOp.ArrayAverageConditional<DistributionStructArray<Gaussian,double>>(vdouble22_B[index0], vdouble22_F[index0], vdouble__7_F[index0], vdouble__7_use_B[index0]);
					for(int index3 = 0; index3<this.vint__1[index0]; index3++) {
						// Message to 'vdouble__4' from GaussianFromMeanAndVariance factor
						vdouble__4_B[index0][index3] = GaussianFromMeanAndVarianceOp.MeanAverageConditional(vdouble__7_use_B[index0][index3], 1.0);
					}
					// Message to 'vdouble15' from Difference factor
					vdouble15_B[index0] = DoublePlusOp.SumAverageConditional(vdouble23_B[index0], vdouble22_F[index0]);
					// Message to 'vdouble__5_use' from Sum factor
					vdouble__5_use_B[index0] = FastSumOp.ArrayAverageConditional<DistributionStructArray<Gaussian,double>>(vdouble15_B[index0], vdouble15_F[index0], vdouble__5_F[index0], vdouble__5_use_B[index0]);
					for(int index2 = 0; index2<this.vint__0[index0]; index2++) {
						// Message to 'vdouble__3' from GaussianFromMeanAndVariance factor
						vdouble__3_B[index0][index2] = GaussianFromMeanAndVarianceOp.MeanAverageConditional(vdouble__5_use_B[index0][index2], 1.0);
					}
					// Message to 'vdouble__2' from Split factor
					this.vdouble__2_B[index0] = SplitOp<double>.ArrayAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian>(vdouble__3_B[index0], this.vint__0[index0], vdouble__4_B[index0], this.vdouble__2_B[index0]);
				}
				this.OnProgressChanged(new ProgressChangedEventArgs(iteration));
			}
			// Message to 'vdouble__0_marginal' from JaggedSubarrayWithMarginal factor
			this.vdouble__0_marginal_F = JaggedSubarrayWithMarginalOp<double>.MarginalAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian,DistributionStructArray<Gaussian,double>>(vdouble__0_F, this.vdouble__2_B, this.vint____0, this.vdouble__0_marginal_F);
			this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of numberOfIterationsDecreased and vint__0 and vint__1 and vint0 and must reset on changes to vint____0 and vint1</summary>
		/// <param name="initialise">If true, reset messages that initialise loops</param>
		private void Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1(bool initialise)
		{
			if (this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone&&((!initialise)||this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isInitialised)) {
				return ;
			}
			for(int index0 = 0; index0<this.vint0; index0++) {
				for(int index4 = 0; index4<this.vint__2[index0]; index4++) {
					this.vdouble__2_B[index0][index4] = Gaussian.Uniform();
				}
			}
			this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone = true;
			this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isInitialised = true;
		}

		/// <summary>Computations that depend on the observed value of vint____0</summary>
		private void Changed_vint____0()
		{
			if (this.Changed_vint____0_isDone) {
				return ;
			}
			// Create array for 'vint____0_marginal' Forwards messages.
			this.vint____0_marginal_F = new PointMass<int[][]>(this.vint____0);
			// Message to 'vint____0_marginal' from DerivedVariable factor
			this.vint____0_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int[][]>,int[][]>(this.vint____0, this.vint____0_marginal_F);
			this.Changed_vint____0_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of vint__0</summary>
		private void Changed_vint__0()
		{
			if (this.Changed_vint__0_isDone) {
				return ;
			}
			// Create array for 'vint__0_marginal' Forwards messages.
			this.vint__0_marginal_F = new PointMass<int[]>(this.vint__0);
			// Message to 'vint__0_marginal' from DerivedVariable factor
			this.vint__0_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int[]>,int[]>(this.vint__0, this.vint__0_marginal_F);
			this.Changed_vint__0_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of vint__0 and vint__1 and vint0</summary>
		private void Changed_vint__0_vint__1_vint0()
		{
			if (this.Changed_vint__0_vint__1_vint0_isDone) {
				return ;
			}
			for(int index0 = 0; index0<this.vint0; index0++) {
				this.vint__2[index0] = checked(this.vint__0[index0]+this.vint__1[index0]);
				// Create array for 'vdouble__2' Backwards messages.
				this.vdouble__2_B[index0] = new DistributionStructArray<Gaussian,double>(this.vint__2[index0]);
			}
			// Create array for 'vint__2_marginal' Forwards messages.
			this.vint__2_marginal_F = new DistributionRefArray<Discrete,int>(this.vint0);
			for(int index0 = 0; index0<this.vint0; index0++) {
				this.vint__2_marginal_F[index0] = ArrayHelper.MakeUniform<Discrete>(Discrete.PointMass(checked(this.vint__0[index0]+this.vint__1[index0]), (checked(this.vint__0[index0]+this.vint__1[index0]))+1));
			}
			// Message to 'vint__2_marginal' from DerivedVariable factor
			this.vint__2_marginal_F = DerivedVariableOp.MarginalAverageConditional<DistributionRefArray<Discrete,int>,int[]>(this.vint__2, this.vint__2_marginal_F);
			this.Changed_vint__0_vint__1_vint0_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of vint__1</summary>
		private void Changed_vint__1()
		{
			if (this.Changed_vint__1_isDone) {
				return ;
			}
			// Create array for 'vint__1_marginal' Forwards messages.
			this.vint__1_marginal_F = new PointMass<int[]>(this.vint__1);
			// Message to 'vint__1_marginal' from DerivedVariable factor
			this.vint__1_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int[]>,int[]>(this.vint__1, this.vint__1_marginal_F);
			this.Changed_vint__1_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of vint0</summary>
		private void Changed_vint0()
		{
			if (this.Changed_vint0_isDone) {
				return ;
			}
			this.vint__2 = new int[this.vint0];
			// Create array for replicates of 'vdouble__2_B'
			this.vdouble__2_B = new DistributionStructArray<Gaussian,double>[this.vint0];
			bool vbool0_reduced = default(bool);
			if (this.vint0>0) {
				vbool0_reduced = true;
				Constrain.Equal<bool>(true, vbool0_reduced);
			}
			this.vint0_marginal_F = new PointMass<int>(this.vint0);
			// Message to 'vint0_marginal' from DerivedVariable factor
			this.vint0_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int>,int>(this.vint0, this.vint0_marginal_F);
			this.Changed_vint0_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of vint1</summary>
		private void Changed_vint1()
		{
			if (this.Changed_vint1_isDone) {
				return ;
			}
			this.vint1_marginal_F = new PointMass<int>(this.vint1);
			// Message to 'vint1_marginal' from DerivedVariable factor
			this.vint1_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int>,int>(this.vint1, this.vint1_marginal_F);
			this.Changed_vint1_isDone = true;
		}

		/// <summary>Update all marginals, by iterating message passing the given number of times</summary>
		/// <param name="numberOfIterations">The number of times to iterate each loop</param>
		/// <param name="initialise">If true, messages that initialise loops are reset when observed values change</param>
		private void Execute(int numberOfIterations, bool initialise)
		{
			if (numberOfIterations!=this.numberOfIterationsDone) {
				if (numberOfIterations<this.numberOfIterationsDone) {
					this.numberOfIterationsDone = 0;
					this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1_isDone = false;
				}
				this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1_isDone = false;
			}
			this.Changed_vint____0();
			this.Changed_vint__1();
			this.Changed_vint__0();
			this.Changed_vint1();
			this.Changed_vint0();
			this.Changed_vint__0_vint__1_vint0();
			this.Changed_numberOfIterationsDecreased_vint__0_vint__1_vint0_Init_vint____0_vint1(initialise);
			this.Changed_numberOfIterations_vint____0_vint__0_vint__1_vint0_vint1(numberOfIterations);
			this.numberOfIterationsDone = numberOfIterations;
		}

		/// <summary>Update all marginals, by iterating message-passing the given number of times</summary>
		/// <param name="numberOfIterations">The total number of iterations that should be executed for the current set of observed values.  If this is more than the number already done, only the extra iterations are done.  If this is less than the number already done, message-passing is restarted from the beginning.  Changing the observed values resets the iteration count to 0.</param>
		public void Execute(int numberOfIterations)
		{
			this.Execute(numberOfIterations, true);
		}

		/// <summary>Get the observed value of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		public object GetObservedValue(string variableName)
		{
			if (variableName=="vint0") {
				return this.vint0;
			}
			if (variableName=="vint1") {
				return this.vint1;
			}
			if (variableName=="vint__0") {
				return this.vint__0;
			}
			if (variableName=="vint__1") {
				return this.vint__1;
			}
			if (variableName=="vint____0") {
				return this.vint____0;
			}
			throw new ArgumentException("Not an observed variable name: "+variableName);
		}

		/// <summary>Get the marginal distribution (computed up to this point) of a variable</summary>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <returns>The marginal distribution computed up to this point</returns>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public object Marginal(string variableName)
		{
			if (variableName=="vint____0") {
				return this.Vint____0Marginal();
			}
			if (variableName=="vint__1") {
				return this.Vint__1Marginal();
			}
			if (variableName=="vint__0") {
				return this.Vint__0Marginal();
			}
			if (variableName=="vint1") {
				return this.Vint1Marginal();
			}
			if (variableName=="vint0") {
				return this.Vint0Marginal();
			}
			if (variableName=="vint__2") {
				return this.Vint__2Marginal();
			}
			if (variableName=="vdouble__0") {
				return this.Vdouble__0Marginal();
			}
			throw new ArgumentException("This class was not built to infer "+variableName);
		}

		/// <summary>Get the marginal distribution (computed up to this point) of a variable, converted to type T</summary>
		/// <typeparam name="T">The distribution type.</typeparam>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <returns>The marginal distribution computed up to this point</returns>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public T Marginal<T>(string variableName)
		{
			return Distribution.ChangeType<T>(this.Marginal(variableName));
		}

		/// <summary>Get the query-specific marginal distribution of a variable.</summary>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <param name="query">QueryType name. For example, GibbsSampling answers 'Marginal', 'Samples', and 'Conditionals' queries</param>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public object Marginal(string variableName, string query)
		{
			if (query=="Marginal") {
				return this.Marginal(variableName);
			}
			throw new ArgumentException(((("This class was not built to infer \'"+variableName)+"\' with query \'")+query)+"\'");
		}

		/// <summary>Get the query-specific marginal distribution of a variable, converted to type T</summary>
		/// <typeparam name="T">The distribution type.</typeparam>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <param name="query">QueryType name. For example, GibbsSampling answers 'Marginal', 'Samples', and 'Conditionals' queries</param>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public T Marginal<T>(string variableName, string query)
		{
			return Distribution.ChangeType<T>(this.Marginal(variableName, query));
		}

		private void OnProgressChanged(ProgressChangedEventArgs e)
		{
			// Make a temporary copy of the event to avoid a race condition
			// if the last subscriber unsubscribes immediately after the null check and before the event is raised.
			EventHandler<ProgressChangedEventArgs> handler = this.ProgressChanged;
			if (handler!=null) {
				handler(this, e);
			}
		}

		/// <summary>Reset all messages to their initial values.  Sets NumberOfIterationsDone to 0.</summary>
		public void Reset()
		{
			this.Execute(0);
		}

		/// <summary>Set the observed value of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		/// <param name="value">Observed value</param>
		public void SetObservedValue(string variableName, object value)
		{
			if (variableName=="vint0") {
				this.vint0 = (int)value;
				return ;
			}
			if (variableName=="vint1") {
				this.vint1 = (int)value;
				return ;
			}
			if (variableName=="vint__0") {
				this.vint__0 = (int[])value;
				return ;
			}
			if (variableName=="vint__1") {
				this.vint__1 = (int[])value;
				return ;
			}
			if (variableName=="vint____0") {
				this.vint____0 = (int[][])value;
				return ;
			}
			throw new ArgumentException("Not an observed variable name: "+variableName);
		}

		/// <summary>Update all marginals, by iterating message-passing an additional number of times</summary>
		/// <param name="additionalIterations">The number of iterations that should be executed, starting from the current message state.  Messages are not reset, even if observed values have changed.</param>
		public void Update(int additionalIterations)
		{
			this.Execute(checked(this.numberOfIterationsDone+additionalIterations), false);
		}

		/// <summary>
		/// Returns the marginal distribution for 'vdouble__0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public DistributionStructArray<Gaussian,double> Vdouble__0Marginal()
		{
			return this.vdouble__0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint____0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int[][]> Vint____0Marginal()
		{
			return this.vint____0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint__0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int[]> Vint__0Marginal()
		{
			return this.vint__0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint__1' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int[]> Vint__1Marginal()
		{
			return this.vint__1_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint__2' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public DistributionRefArray<Discrete,int> Vint__2Marginal()
		{
			return this.vint__2_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int> Vint0Marginal()
		{
			return this.vint0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint1' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int> Vint1Marginal()
		{
			return this.vint1_marginal_F;
		}

		#endregion

		#region Events
		/// <summary>Event that is fired when the progress of inference changes, typically at the end of one iteration of the inference algorithm.</summary>
		public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
		#endregion

	}

}