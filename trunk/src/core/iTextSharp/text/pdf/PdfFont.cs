using System;
using iTextSharp.text;
/*
 * $Id$
 * 
 *
 * This file is part of the iText project.
 * Copyright (c) 1998-2013 1T3XT BVBA
 * Authors: Bruno Lowagie, Paulo Soares, et al.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License version 3
 * as published by the Free Software Foundation with the addition of the
 * following permission added to Section 15 as permitted in Section 7(a):
 * FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY 1T3XT,
 * 1T3XT DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU Affero General Public License for more details.
 * You should have received a copy of the GNU Affero General Public License
 * along with this program; if not, see http://www.gnu.org/licenses or write to
 * the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
 * Boston, MA, 02110-1301 USA, or download the license from the following URL:
 * http://itextpdf.com/terms-of-use/
 *
 * The interactive user interfaces in modified source and object code versions
 * of this program must display Appropriate Legal Notices, as required under
 * Section 5 of the GNU Affero General Public License.
 *
 * In accordance with Section 7(b) of the GNU Affero General Public License,
 * you must retain the producer line in every PDF that is created or manipulated
 * using iText.
 *
 * You can be released from the requirements of the license by purchasing
 * a commercial license. Buying such a license is mandatory as soon as you
 * develop commercial activities involving the iText software without
 * disclosing the source code of your own applications.
 * These activities include: offering paid services to customers as an ASP,
 * serving PDFs on the fly in a web application, shipping iText with a closed
 * source product.
 *
 * For more information, please contact iText Software Corp. at this
 * address: sales@itextpdf.com
 */

namespace iTextSharp.text.pdf {
    /**
    * <CODE>PdfFont</CODE> is the Pdf Font object.
    * <P>
    * Limitation: in this class only base 14 Type 1 fonts (courier, courier bold, courier oblique,
    * courier boldoblique, helvetica, helvetica bold, helvetica oblique, helvetica boldoblique,
    * symbol, times roman, times bold, times italic, times bolditalic, zapfdingbats) and their
    * standard encoding (standard, MacRoman, (MacExpert,) WinAnsi) are supported.<BR>
    * This object is described in the 'Portable Document Format Reference Manual version 1.3'
    * section 7.7 (page 198-203).
    *
    * @see        PdfName
    * @see        PdfDictionary
    * @see        BadPdfFormatException
    */

    public class PdfFont : IComparable<PdfFont> {
        
        
        /** the font metrics. */
        private BaseFont font;
        
        /** the size. */
        private float size;
        
        protected float hScale = 1;
        
        // constructors
        
        internal PdfFont(BaseFont bf, float size) {
            this.size = size;
            font = bf;
        }
        
        // methods
        
        /**
        * Compares this <CODE>PdfFont</CODE> with another
        *
        * @param    object    the other <CODE>PdfFont</CODE>
        * @return    a value
        */
        
        virtual public int CompareTo(PdfFont pdfFont) {
            if (pdfFont == null) {
                return -1;
            }
            try {
                if (font != pdfFont.font) {
                    return 1;
                }
                if (this.Size != pdfFont.Size) {
                    return 2;
                }
                return 0;
            }
            catch (InvalidCastException) {
                return -2;
            }
        }
        
        /**
        * Returns the size of this font.
        *
        * @return        a size
        */
        
        internal float Size {
            get { return size; }
        }
        
        /**
        * Returns the approximative width of 1 character of this font.
        *
        * @return        a width in Text Space
        */
        
        internal float Width() {
            return Width(' ');
        }
        
        /**
        * Returns the width of a certain character of this font.
        *
        * @param        character    a certain character
        * @return        a width in Text Space
        */
        
        internal float Width(int character) {
                return font.GetWidthPoint(character, size) * hScale;
        }
        
        internal float Width(String s) {
            return font.GetWidthPoint(s, size) * hScale;
        }
        
        internal BaseFont Font {
            get { 
                return font;
            }
        }
        
        internal static PdfFont DefaultFont {
            get {
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, false);
                return new PdfFont(bf, 12);
            }
        }

        internal float HorizontalScaling {
            set {
                this.hScale = value;
            }

            get {
                return hScale;
            }
        }
    }
}
