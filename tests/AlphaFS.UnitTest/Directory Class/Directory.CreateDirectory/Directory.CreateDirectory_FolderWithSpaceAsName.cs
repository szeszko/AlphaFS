/*  Copyright (C) 2008-2018 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlphaFS.UnitTest
{
   public partial class Directory_CreateDirectoryTest
   {
      // Pattern: <class>_<function>_<scenario>_<expected result>


      [TestMethod]
      public void AlphaFS_Directory_CreateDirectory_FolderWithSpaceAsName_LocalAndNetwork_Success()
      {
         Directory_CreateDirectory_FolderWithSpaceAsName(false);
         Directory_CreateDirectory_FolderWithSpaceAsName(true);
      }


      private void Directory_CreateDirectory_FolderWithSpaceAsName(bool isNetwork)
      {
         using (var tempRoot = new TemporaryDirectory(isNetwork))
         {
            var folder = tempRoot.Directory.FullName;

            Console.WriteLine("Input Directory Path: [{0}]", folder);


            var numSpace = 1;
            var spaceFolder1 = folder + @"\" + new string(' ', numSpace);

            var dirInfo1 = Alphaleonis.Win32.Filesystem.Directory.CreateDirectory(spaceFolder1, Alphaleonis.Win32.Filesystem.PathFormat.LongFullPath);

            Assert.IsTrue(dirInfo1.Exists, "The folder with " + numSpace + " space does not exist, but is expected to.");


            numSpace = 5;
            var spaceFolder2 = folder + @"\" + new string(' ', numSpace);

            var dirInfo2 = Alphaleonis.Win32.Filesystem.Directory.CreateDirectory(spaceFolder2, Alphaleonis.Win32.Filesystem.PathFormat.LongFullPath);

            Assert.IsTrue(dirInfo2.Exists, "The folder with " + numSpace + " spaces does not exist, but is expected to.");
         }

         Console.WriteLine();
      }
   }
}
