﻿using System;
using System.Runtime.CompilerServices;

namespace Vortice.Direct2D1.Effects
{
    using Props = DiscreteTransferProperties;
    public class DiscreteTransfer : ID2D1Effect
    {
        public DiscreteTransfer(ID2D1DeviceContext deviceContext) : base(IntPtr.Zero)
        {
            deviceContext.CreateEffect(EffectGuids.DiscreteTransfer, this);
        }

        int redTableSize = 2;
        int greenTableSize = 2;
        int blueTableSize = 2;
        int alphaTableSize = 2;
        public unsafe float[] RedTable
        {
            set
            {
                redTableSize = value.Length;
                if (redTableSize == 0)
                    throw new ArgumentException();
                SetValue((int)Props.RedTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref value[0])), sizeof(float) * redTableSize);
            }
            get
            {
                var table = new float[redTableSize];
                GetValue((int)Props.RedTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref table[0])), sizeof(float) * redTableSize);
                return table;
            }
        }
        public unsafe float[] GreenTable
        {
            set
            {
                greenTableSize = value.Length;
                if (greenTableSize == 0)
                    throw new ArgumentException();
                SetValue((int)Props.GreenTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref value[0])), sizeof(float) * greenTableSize);
            }
            get
            {
                var table = new float[greenTableSize];
                GetValue((int)Props.GreenTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref table[0])), sizeof(float) * greenTableSize);
                return table;
            }
        }
        public unsafe float[] BlueTable
        {
            set
            {
                blueTableSize = value.Length;
                if (blueTableSize == 0)
                    throw new ArgumentException();
                SetValue((int)Props.BlueTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref value[0])), sizeof(float) * blueTableSize);
            }
            get
            {
                var table = new float[blueTableSize];
                GetValue((int)Props.BlueTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref table[0])), sizeof(float) * blueTableSize);
                return table;
            }
        }
        public unsafe float[] AlphaTable
        {
            set
            {
                alphaTableSize = value.Length;
                if (alphaTableSize == 0)
                    throw new ArgumentException();
                SetValue((int)Props.AlphaTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref value[0])), sizeof(float) * alphaTableSize);
            }
            get
            {
                var table = new float[alphaTableSize];
                GetValue((int)Props.AlphaTable, PropertyType.Blob, new IntPtr(Unsafe.AsPointer(ref table[0])), sizeof(float) * alphaTableSize);
                return table;
            }
        }
        public bool RedDisable
        {
            set => SetValue((int)Props.RedDisable, value);
            get => GetBoolValue((int)Props.RedDisable);
        }
        public bool GreenDisable
        {
            set => SetValue((int)Props.GreenDisable, value);
            get => GetBoolValue((int)Props.GreenDisable);
        }
        public bool BlueDisable
        {
            set => SetValue((int)Props.BlueDisable, value);
            get => GetBoolValue((int)Props.BlueDisable);
        }
        public bool AlphaDisable
        {
            set => SetValue((int)Props.AlphaDisable, value);
            get => GetBoolValue((int)Props.AlphaDisable);
        }
        public bool ClampOutput
        {
            set => SetValue((int)Props.ClampOutput, value);
            get => GetBoolValue((int)Props.ClampOutput);
        }
    }
}
