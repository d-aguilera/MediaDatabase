using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace MediaDatabase.Hasher
{
    class WmiHelpers
    {
        public static void GetVolumeInfo(string path, out string mediumCaption, out long mediumSize, out string mediumSerialNumber, out string mediumTypeName, out string partitionCaption, out int partitionDiskIndex, out int partitionIndex, out string volumeCaption, out string volumeFileSystem, out string volumeName, out string volumeSerialNumber)
        {
            volumeSerialNumber = GetVolumeSerialNumber(path);

            var volume = GetVolumeBySerialNumber(volumeSerialNumber);
            volumeCaption = (string)volume["Caption"];
            volumeFileSystem = (string)volume["FileSystem"];
            volumeName = (string)volume["VolumeName"];
            var volumeDeviceId = (string)volume["DeviceID"];

            var partition = GetPartitionFromVolume(volumeDeviceId);
            var partitionDeviceId = (string)partition["DeviceID"];
            partitionCaption = (string)partition["Caption"];
            partitionIndex = Convert.ToInt32(partition["Index"], CultureInfo.InvariantCulture);
            partitionDiskIndex = Convert.ToInt32(partition["DiskIndex"], CultureInfo.InvariantCulture);

            var diskDrive = GetDiskDriveFromPartition(partitionDeviceId);
            mediumCaption = (string)diskDrive["Caption"];
            mediumTypeName = (string)diskDrive["MediaType"];
            mediumSize = Convert.ToInt64(diskDrive["Size"], CultureInfo.InvariantCulture);
            mediumSerialNumber = (string)diskDrive["SerialNumber"];
        }

        static string GetVolumeSerialNumber(string path)
        {
            var root = Path.GetPathRoot(path);
            uint volumeSerialNumber, maximumComponentLength, fileSystemFlags;
            NativeMethods.GetVolumeInformation(root, null, 0U, out volumeSerialNumber, out maximumComponentLength, out fileSystemFlags, null, 0U);
            return volumeSerialNumber.ToString("X", CultureInfo.InvariantCulture);
        }

        static ManagementBaseObject GetVolumeBySerialNumber(string volumeSerialNumber)
        {
            var query = ""
                + "SELECT * "
                + "FROM Win32_LogicalDisk "
                + "WHERE VolumeSerialNumber = '" + volumeSerialNumber + "'"
                ;
            var mocs = QueryWmi(query);
            foreach (var moc in mocs)
                return moc;
            return null;
        }

        static ManagementBaseObject GetPartitionFromVolume(string volumeDeviceId)
        {
            var query = ""
                + "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + volumeDeviceId + "'} "
                + "WHERE AssocClass=Win32_LogicalDiskToPartition "
                + "KEYSONLY"
                ;
            var mocs = QueryWmi(query);
            foreach (var moc in mocs)
                return moc;
            return null;
        }

        static ManagementBaseObject GetDiskDriveFromPartition(string partitionDeviceId)
        {
            var query = ""
                + "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partitionDeviceId + "'} "
                + "WHERE AssocClass=Win32_DiskDriveToDiskPartition"
                ;
            var mocs = QueryWmi(query);
            foreach (var moc in mocs)
                return moc;
            return null;
        }

        static IEnumerable<ManagementBaseObject> QueryWmi(string query)
        {
            var searcher = new ManagementObjectSearcher(query);
            foreach (var moc in searcher.Get())
                yield return moc;
        }
    }
}
