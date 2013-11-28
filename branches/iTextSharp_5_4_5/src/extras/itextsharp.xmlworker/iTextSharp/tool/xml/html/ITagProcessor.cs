using System;
using System.Collections.Generic;
using iTextSharp.text;
/*
 * $Id: ITagProcessor.java 122 2011-05-27 12:20:58Z redlab_b $
 *
 * This file is part of the iText (R) project.
 * Copyright (c) 1998-2012 1T3XT BVBA
 * Authors: Balder Van Camp, Emiel Ackermann, et al.
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
 * a covered work must retain the producer line in every PDF that is created
 * or manipulated using iText.
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
namespace iTextSharp.tool.xml.html {

    /**
     * @author redlab_b
     *
     */
    public interface ITagProcessor {


        /**
         * This method is called when a tag has been encountered.
         *
         * @param tag the tag encountered
         * @return IElement an IElement to add to the current content;
         */
        IList<IElement> StartElement(IWorkerContext ctx, Tag tag);

        /**
         * This method is called if there is text content encountered between the
         * opening and closing tags this ITagProcessor is mapped to.
         *
         * @param tag the tag encountered
         * @param content the text content between the tags this ITagProcessor is
         *        mapped to.
         * @return the element to add to the currentContent list
         */
        IList<IElement> Content(IWorkerContext ctx, Tag tag, String content);

        /**
         * This method is called when a closing tag has been encountered of the
         * ITagProcessor implementation that is mapped to the tag.
         *
         * @param tag the tag encountered
         * @param currentContent a list of content possibly created by TagProcessing
         *            of inner tags, and by <code>startElement</code> and
         *            <code>content</code> methods of this <code>ITagProcessor</code>
         *            .
         * @return the resulting element to add to the document or a content stack.
         */
        IList<IElement> EndElement(IWorkerContext ctx, Tag tag, IList<IElement> currentContent);

        /**
         * @return true if the tag implementation must keep it's own currentContent
         *         stack.
         */
        bool IsStackOwner();
    }
}