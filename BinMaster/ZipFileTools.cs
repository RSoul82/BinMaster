using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace BinMaster
{
    class ZipFileTools
    {
        /// <summary>
        /// Extract a file from a .crf/zip
        /// </summary>
        /// <param name="fileToExtract"></param>
        /// <param name="zip">ZipFile object.</param>
        /// <param name="extractionDir">Where to extract the file.</param>
        /// <param name="dontUseFolderStructure">Extract file only and ignore any of the zip's subfolder structure.</param>
        /// <param name="usingEPcrf">EP.crf uses obj or mesh root folders.</param>
        public static void ExtractFile(string fileToExtract, ZipFile zip, string extractionDir, bool dontUseFolderStructure, bool usingEPcrf, out bool modelExtracted)
        {
            string fullPathToFile = "";
            if(usingEPcrf) fullPathToFile = setCrfRootFolder(fileToExtract);
            else fullPathToFile = fileToExtract;

            zip.FlattenFoldersOnExtract = dontUseFolderStructure;
            ZipEntry e = zip[fullPathToFile];
            e.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
            e.Extract(extractionDir);
            modelExtracted = true;
        }

        /// <summary>
        /// Extract a texture from a crf file.
        /// </summary>
        /// <param name="textureToExtract">Simple filename.</param>
        /// <param name="crfFilePath">Path to crf file.</param>
        /// <param name="extractionDir">Dir to extract the file to.</param>
        /// <param name="dontUseFolderStructure">Don't maintain folder structure.</param>
        /// <param name="objType">Determines where to start looking in EP.crf</param>
        internal static void ExtractTexture(string textureToExtract, string crfFilePath, string extractionDir, bool dontUseFolderStructure, ObjectType objType)
        {
            using(ZipFile zip = ZipFile.Read(crfFilePath))
            {
                string pathStart = "";
                string fullPath = "";
                if(objType == ObjectType.Object) pathStart = "Obj/";
                else if(objType == ObjectType.Mesh) pathStart = "Mesh/";

                zip.FlattenFoldersOnExtract = dontUseFolderStructure;
                ZipEntry e = new ZipEntry();

                if(zip.ContainsEntry(fullPath = pathStart + "txt16/" + textureToExtract))
                    e = zip[fullPath];
                else if(zip.ContainsEntry(fullPath = pathStart + "txt/" + textureToExtract))
                    e = zip[fullPath];

                e.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                e.Extract(extractionDir);
            }
        }

        internal static void ExtractTexture(ZipFile zip, string textureToExtract, string extractionDir, bool dontUseFolderStructure)
        {
            string fullPath = "";

            zip.FlattenFoldersOnExtract = dontUseFolderStructure;
            ZipEntry e = new ZipEntry();

            if (zip.ContainsEntry(fullPath = "txt16/" + textureToExtract))
                e = zip[fullPath];
            else if (zip.ContainsEntry(fullPath = "txt/" + textureToExtract))
                e = zip[fullPath];

            e.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
            e.Extract(extractionDir);
        }

        internal static void ExtractTextureEP(ZipFile zip, string modelFolder, string textureToExtract, string extractionDir, bool dontUseFolderStructure)
        {
            string fullPath = "";

            zip.FlattenFoldersOnExtract = dontUseFolderStructure;
            ZipEntry e = new ZipEntry();

            if (zip.ContainsEntry(fullPath = modelFolder +  "/txt16/" + textureToExtract))
                e = zip[fullPath];
            else if (zip.ContainsEntry(fullPath = modelFolder + "/txt/" + textureToExtract))
                e = zip[fullPath];

            e.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
            e.Extract(extractionDir);
        }

        /// <summary>
        /// Looks in a crf file to see if the file exists.
        /// </summary>
        /// <param name="zip">Zip file object.</param>
        /// <param name="fileInCrf">Short filename with extension.</param>
        /// <param name="usingEPcrf">Make use of ep2.crf having a slightly different folder structure to obj/mesh crf.</param>
        /// <returns></returns>
        internal static bool FindFile(ZipFile zip, string fileInCrf, bool usingEPcrf)
        {
            string fullPathToFile = "";
            bool found = false;
            if(usingEPcrf) fullPathToFile = setCrfRootFolder(fileInCrf);
            else
                fullPathToFile = fileInCrf;

            if (zip.ContainsEntry(fullPathToFile))
                found = true;
            return found;
        }

        /// <summary>
        /// Returns True if the texture is found in the crf file.
        /// </summary>
        /// <param name="zip">ZipFile object.</param>
        /// <param name="textureInCrf">Simple texture filename with extension.</param>
        /// <param name="objType">Determines the root folder of the EP (Obj/ or Mesh/)</param>
        /// <returns></returns>
        internal static bool FindTextureEP(ZipFile zip, string modelFolder, string textureInCrf)
        {
            bool found = false;

            if(zip.ContainsEntry(modelFolder + "/txt16/" + textureInCrf)) 
                found = true;
            else if(zip.ContainsEntry(modelFolder + "/txt/" + textureInCrf)) 
                found = true;
            
            return found;
        }

        /// <summary>
        /// Returns True if the texture is found in the crf file.
        /// </summary>
        /// <param name="textureInCrf">Simple texture filename.</param>
        /// <param name="crfFilePath">Full path of crf file.</param>
        /// <returns></returns>
        internal static bool FindTexture(ZipFile zip, string textureInCrf)
        {
            bool found = false;

            if (zip.ContainsEntry("txt16/" + textureInCrf))
                found = true;
            else if (zip.ContainsEntry("txt/" + textureInCrf))
                found = true;

            return found;
        }

        /// <summary>
        /// Obj/Mesh crf have bin/e files in the root. EP.crf and other packs start with obj/ and mesh/
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string setCrfRootFolder(string fileName)
        {
            string pathWithRoot = "";
            //EP files are in Obj and Mesh root dirs
            if(fileName.EndsWith(".bin")) pathWithRoot = "Obj/" + fileName;
            else if(fileName.EndsWith(".e")) pathWithRoot = "Mesh/" + fileName;

            return pathWithRoot;
        }
    }
}
