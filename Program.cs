using System;
using System.Text;

namespace CrcCalculator
{
    class Program
    {
        //Code in php 
        // function calcCrc($data)
        //{
        //$crc = 0xFFFF;
        //    for ($i = 0; $i < strlen($data); $i++) {
        //    $x = (($crc >> 8) ^ord($data[$i])) &0xFF;
        //    $x ^= $x >> 4;
        //    $crc = (($crc << 8) ^($x << 12) ^($x << 5) ^ $x) &0;
        //    }
        //    return strtoupper(dechex($crc));
        //}
        // $data = "00020101021229480008000001290212www.logus.am0316Երևան, Մաշտոց 50520452335802AM5912COMPANY NAME6007Yerevan54010530305155020357040.3662260805362900505362900204sdsd92330013PX00104042018010110207PAYX_QR6304";
        //$data.=calCrc($data);
        //echo $data;

        private static string CalcCrc(string qr)
        {
            ulong crc = 0xFFFF;
            for (int i = 0; i < qr.Length; i++)
            {
                ulong x = ((crc >> 8) ^ (qr[i])) & 0xFF;
                x ^= x >> 4;
                crc = ((crc << 8) ^ (x << 12) ^ (x << 5) ^ x) & 0xFFFF;
            }
            return (crc).ToString("X");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Old qr");
            string oldQr = "00020101021229480008000001290212www.logus.am0316Երևան, Մաշտոց 50520452335802AM5912COMPANY NAME6007Yerevan54010530305155020357040.3662260805362900505362900204sdsd92330013PX00104042018010110207PAYX_QR6304CA39";
            Console.WriteLine(oldQr);
            Console.WriteLine();
            Console.WriteLine("New qr");
            string newQr = "00020101021229480008000001290212www.logus.am0316Երևան, Մաշտոց 50520452335802AM5912COMPANY NAME6007Yerevan54010530305155020357040.3662260805362900505362900204sdsd92330013PX00104042018010110207PAYX_QR6304";
            newQr += CalcCrc(newQr);
            Console.WriteLine(newQr);
        }
    }
}
