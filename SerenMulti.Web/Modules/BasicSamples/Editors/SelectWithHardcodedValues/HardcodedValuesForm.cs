﻿using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace SerenMulti.BasicSamples.Forms
{
    [FormScript("BasicSamples.HarcodedValues")]
    public class HardcodedValuesForm
    {
        [DisplayName("Some Value")]
        [HardcodedValuesEditor]
        public String SomeValue { get; set; }
    }
}