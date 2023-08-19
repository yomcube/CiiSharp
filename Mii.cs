// Mii data
// WiiBrew
// https://wiibrew.org/wiki/Mii_data

// Special Miis
// David Hawley
// https://web.archive.org/web/20080717043753/http://www.davidhawley.co.uk:80/special-miis-gold-pants-and-creating.aspx

using System;
using System.Collections;
using System.IO;

namespace CiiSharp
{
	public class Mii
	{
		
		public static Mii FromFile(string filename)
		{
			byte[] bytes = File.ReadAllBytes(filename);
			BitArray bits = new BitArray(bytes);
		}
		// TODO: this method
		public void SaveToFile(string filename)
		{
			byte[] bytes = ToBytesNoChecksum();
			int crc = CrcChecksum(bytes);
			
		}
		
		public const int NameLength    = 10;
		public const int CreatorLength = 10;
		
		// addr 0x00 - 0x01
		public bool   Unknown_0x00_0; // 1bit | Doesn't seem to have any effect
		public bool   IsFemale;       // 1bit |
		public bool[] Month;          // 4bit |
		public bool[] Day;            // 5bit |
		public bool[] FavColor;       // 4bit | 0 - 11 | Some values over 11 will crash the Wii when trying to change the favorite color
		public bool   IsFavorite;     // 1bit |
		
		// addr 0x02 - 0x15
		public ushort[] Name; // Must be of length NameLength
		
		// addr 0x16
		public byte Height; // 0x00 - 0x7F
		
		// addr 0x17
		public byte Weight; // 0x00 - 0x7F
		
		// addr 0x18 - 0x1B
		// Can be used for special miis.
		// See the link at the top.
		public byte MiiId1;
		public byte MiiId2;
		public byte MiiId3;
		public byte MiiId4;
		
		// addr 0x1C - 0x1F
		public byte SystemId1; // 8bit
		public byte SystemId2; // 8bit
		public byte SystemId3; // 8bit
		public byte SystemId4; // 8bit |
		
		// addr 0x20 - 0x21
		public bool[] FaceShape;      // 3bit |
		public bool[] SkinColor;      // 3bit | 0 - 5
		public bool[] FacialFeature;  // 4bit | 0 - 11
		public bool[] Unknown_0x21_2; // 3bit | Mii appears unaffected by changes to this data
		public bool   MingleOff;      // 1bit |
		public bool   Unknown_0x21_6; // 1bit | Mii appears unaffected by changes to this data
		public bool   Downloaded;     // 1bit | Downloaded from the Check Mii Out Channel
		
		// addr 0x22 - 0x23
		public bool[] HairType;       // 7bit | 0 - 71 | Value is non-sequential with regard to page, row and column
		public bool[] HairColor;      // 3bit |
		public bool   HairPart;       // 1bit | 0 = Normal, 1 = Reversed
		public bool[] Unknown_0x23_3; // 5bit |
		
		// addr 0x24 - 0x27
		public bool[] EyebrowType;        // 5bit | 0 - 23 | Value is non-sequential with regard to page, row and column
		public bool   Unknown_0x24_5;     // 1bit |
		public bool[] EyebrowRotation;    // 4bit | 0 - 11 | Default value varies based on eyebrow type
		public bool[] Unknown_0x25_1;     // 6bit |
		public bool[] EyebrowColor;       // 3bit |
		public bool[] EyebrowSize;        // 4bit | 0 -  8 | Default =  4
		public bool[] EyebrowVerticalPos; // 5bit | 3 - 18 | Default = 10
		public bool[] EyebrowSpacing;     // 4bit | 0 - 12 | Default =  2
		
		// addr 0x28 - 0x2B
		public bool[] EyeType;        // 6bit | 0 - 47 | Value is non-sequential with regard to page, row and column
		public bool[] Unknown_0x28_6; // 2bit |
		public bool[] EyeRotation;    // 3bit | 0 -  7 | Default value varies based on eye type
		public bool[] EyeVerticalPos; // 5bit | 0 - 18 | Default = 12, Smaller number = higher up
		public bool[] EyeColor;       // 3bit |
		public bool[] EyeSize;        // 3bit | Default = 0x04
		public bool[] EyeSpacing;     // 4bit | 0 - 12 | Default = 2
		public bool[] Unknown_0x2B_3; // 5bit |
		
		// addr 0x2C - 0x2D
		public bool[] NoseType;        // 4bit | 0 - 11 | Value is non-sequential with regard to page, row and column
		public bool[] NoseSize;        // 4bit | 0 -  8 | Default = 4
		public bool[] NoseVerticalPos; // 5bit | 0 - 18 | Default = 9
		public bool[] Unknown_0x2D_5;  // 3bit |
		
		// addr 0x2E - 0x2F
		public bool[] LipType;        // 5bit | 0 - 23 | Value is non-sequential with regard to page, row and column
		public bool[] LipColor;       // 2bit | 0 -  2 |
		public bool[] LipSize;        // 4bit | 0 -  8 | Default =  4
		public bool[] LipVerticalPos; // 5bit | 0 - 18 | Default = 13
		
		// addr 0x30 - 0x31
		public bool[] GlassesType;        // 4bit | 0 - 8
		public bool[] GlassesColor;       // 3bit | 0 - 5
		public bool   Unknown_0x30_7;     // 1bit |
		public bool[] GlassesSize;        // 3bit | Default = 4
		public bool[] GlassesVerticalPos; // 5bit | 0 - 20 | Default = 10
		
		// addr 0x32 - 0x33
		public bool[] MustacheType;        // 2bit |
		public bool[] BeardType;           // 2bit |
		public bool[] FacialHairColor;     // 3bit |
		public bool[] MustacheSize;        // 4bit | 0 -  8 | Default =  4
		public bool[] MustacheVerticalPos; // 5bit | 0 - 16 | Default = 10
		
		// addr 0x34 - 0x35
		public bool   MoleOn;            // 1bit |
		public bool[] MoleSize;          // 4bit | 0 -  8 | Default =  4
		public bool[] MoleVerticalPos;   // 5bit | 0 - 30 | Default = 20
		public bool[] MoleHorizontalPos; // 5bit | 0 - 16 | Default = 2
		public bool   Unknown_0x35_7;    // 1bit |
		
		// addr 0x36 - 0x49
		public ushort[] CreatorName; // Must be of length CreatorLength
		
		// TODO: this method
		public byte[] ToBytesNoChecksum()
		{
			BitArray bitarr = new BitArray(584); // 0x49 * 8
			
		}
		
		 /**
		  * Calculate a modified CRC16-CCITT checksum of a byte array, as used for
		  * checking the validity of a Mii data block stored on a Wiimote.
		  *
		  * @param bytes the byte array to calculate the checksum for
		  * @return the checksum (in the lower 16 bits)
		  */
		public static int CrcChecksum (byte[] bytes) {
			int crc = 0x0000;
			for (int byteIndex = 0; byteIndex < bytes.length; byteIndex++) {
				for (int bitIndex = 7; bitIndex >= 0; bitIndex--) {
					crc = (((crc << 1) | ((bytes[byteIndex] >> bitIndex) & 0x1)) ^
					(((crc & 0x8000) != 0) ? 0x1021 : 0)); 
				}
			}
			for (int counter = 16; counter > 0; counter--) {
				crc = ((crc << 1) ^ (((crc & 0x8000) != 0) ? 0x1021 : 0));
			}
			return (crc & 0xFFFF);
		}
	}
}
