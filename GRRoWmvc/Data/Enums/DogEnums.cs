using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Data.Enums
{
    public enum DogGenderEnum : int
    {
        Male,
        MaleNeutered,
        Female,
        FemaleSpayed
    }

    public enum DogEnergyEnum : int
    {
        Low,
        LowMedium,
        Medium,
        MediumHigh,
        High
    }

    public enum InteractionWithDogsEnum : int
    {
        Unknown,
        Good,
        GoodWithMostDogs,
        PrefersOnlyDog
    }

    public enum InteractionWithKidsEnum : int
    {
        Unknown,
        Good,
        GoodWithMostKids,
        InteractionNotPreferred
    }

    public enum InteractionWithCatsEnum : int
    {
        Unknown,
        Good,
        InteractionNotPreferred
    }

    public enum DogStatusEnum : int
    {
        InFosterCare,
        MedicalHold,
        BehavioralHold,
        ForeverFoster,
        Adopted,
        Bridge
    }
}
