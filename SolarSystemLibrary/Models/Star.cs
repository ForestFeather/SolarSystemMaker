// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - Star.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:14 AM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Star. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="IStar"/>
    ///=================================================================================================
    public class Star : IStar {
        #region Implementation of IStar

        ///=================================================================================================
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <seealso cref="IStar.Category"/>
        ///
        /// ### <value> The category. </value>
        ///=================================================================================================
        public StarCategory Category { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the main sequence star. </summary>
        ///
        /// <seealso cref="IStar.MainSequenceStar"/>
        ///
        /// ### <value> true if main sequence star, false if not. </value>
        ///=================================================================================================
        public bool MainSequenceStar { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the solar mass. </summary>
        ///
        /// <seealso cref="IStar.SolarMass"/>
        ///
        /// ### <value> The solar mass. </value>
        ///=================================================================================================
        public double SolarMass { get; set; }

        #endregion

        #region Overrides of Object

        ///=================================================================================================
        /// <summary>
        ///     Returns a <see cref="T:System.String"/> that represents the current
        ///     <see cref="T:System.Object"/>.
        /// </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="object.ToString()"/>
        ///
        /// ### <returns>
        ///     A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        ///=================================================================================================
        public override string ToString( ) {
            return
                string.Format(
                    "Star Size: {0}\r\n\tSolar Mass: {1}\t\tMain Sequence Star: {2}\r\n",
                    this.Category,
                    this.SolarMass,
                    this.MainSequenceStar );
        }

        #endregion
    }
}
