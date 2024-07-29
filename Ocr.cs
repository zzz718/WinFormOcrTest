using Microsoft.Win32.SafeHandles;
using PaddleOCRSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormOcrTest
{
    public class Ocr : IDisposable
    {
        
        public string GetFilePath(string FilePath)
        {
            // 指定输入图片文件的路径
            string imageFilePath = FilePath;

            string scannedText = "";
            var imagebyte = File.ReadAllBytes(imageFilePath);
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));
             scannedText = OcrForChinese(bitmap);

            bitmap.Dispose();
            // 将文字识别结果返回给调用者
            return scannedText;
        }

        public string OcrForChinese(Bitmap bitmap)
        {
            // 创建OCR引擎
            OCRModelConfig config = null;
            OCRParameter oCRParameter = new OCRParameter();
            //oCRParameter.use_gpu=1;当使用GPU版本的预测库时，该参数打开才有效果
            OCRResult ocrResult = new OCRResult();
            string scannedText = "";
            PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter);
            // 识别图片中的文字
            ocrResult = engine.DetectText(bitmap);
            if (ocrResult != null)
            {
                scannedText = ocrResult.Text;
            }
            
            return scannedText;
        }

        //实现IDisposable接口，释放资源
        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }
}
