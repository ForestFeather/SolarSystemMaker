// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - Toxicity.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 2:18 PM, 27/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

using System.ComponentModel;

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Values that represent Toxicity. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public enum Toxicity {
        /// <summary>   . </summary>
        [Description("Inert Gases")] 
        InertGas = -2,

        /// <summary>   . </summary>
        [Description("Noble Gases")] 
        NobleGas,

        /// <summary>   . </summary>
        [Description("Earth Atmosphere")]
        EarthAtmosphere,

        /// <summary>   . </summary>
        [Description("Mildly Toxic")] 
        MildToxicity,

        /// <summary>   . </summary>
        [Description("Volcanic Ash")] 
        VolcanicAsh,

        /// <summary>   . </summary>
        [Description("Chemical Weapons")] 
        ChemicalWeapon
    }
}
