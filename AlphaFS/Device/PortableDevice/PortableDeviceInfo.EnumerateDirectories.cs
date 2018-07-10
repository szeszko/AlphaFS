﻿/*  Copyright (C) 2008-2018 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
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

using System.Collections.Generic;
using System.Linq;
using System.Security;
using Alphaleonis.Win32.Filesystem;

namespace Alphaleonis.Win32.Device
{
   public sealed partial class PortableDeviceInfo
   {
      /// <summary>[AlphaFS] Returns an enumerable collection of directory names from the root of the device.</summary>
      /// <returns>An enumerable collection of file-system entries from the root of the device.</returns>
      [SecurityCritical]
      public IEnumerable<WpdDirectoryInfo> EnumerateDirectories()
      {
         return EnumerateFileSystemEntryInfoCore(this, null, null, false, true).Cast<WpdDirectoryInfo>();
      }


      /// <summary>[AlphaFS] Returns an enumerable collection of directory names from the root of the device.</summary>
      /// <returns>An enumerable collection of file-system entries from the root of the device.</returns>
      /// <param name="recurse"><c>true</c> to recurse into subdirectories.</param>
      [SecurityCritical]
      public IEnumerable<WpdDirectoryInfo> EnumerateDirectories(bool recurse)
      {
         return EnumerateFileSystemEntryInfoCore(this, null, null, recurse, true).Cast<WpdDirectoryInfo>();
      }


      /// <summary>[AlphaFS] Returns an enumerable collection of directory instances in a specified path.</summary>
      /// <returns>An enumerable collection of file-system entries in the directory specified by <paramref name="objectId"/>.</returns>
      /// <param name="objectId">The ID of the directory to search.</param>
      /// <param name="recurse"><c>true</c> to recurse into subdirectories.</param>
      [SecurityCritical]
      public IEnumerable<WpdDirectoryInfo> EnumerateDirectories(string objectId, bool recurse)
      {
         return EnumerateFileSystemEntryInfoCore(this, null, objectId, recurse, true).Cast<WpdDirectoryInfo>();
      }
   }
}