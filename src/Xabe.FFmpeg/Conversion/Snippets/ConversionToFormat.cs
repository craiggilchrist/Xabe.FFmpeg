﻿using System.Linq;

namespace Xabe.FFmpeg
{
    public partial class Conversion
    {
        /// <summary>
        ///     Convert file to MP4
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <returns>Conversion result</returns>
        internal static IConversion ToMp4(string inputPath, string outputPath)
        {
            IMediaInfo info = FFmpeg.GetMediaInfo(inputPath).GetAwaiter().GetResult();

            IStream videoStream = info.VideoStreams.FirstOrDefault()
                                      ?.SetCodec(VideoCodec.h264);
            IStream audioStream = info.AudioStreams.FirstOrDefault()
                                      ?.SetCodec(AudioCodec.aac);

            return New()
                .AddStream(videoStream, audioStream)
                .SetOutput(outputPath);
        }

        /// <summary>
        ///     Convert file to TS
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <returns>Conversion result</returns>
        internal static IConversion ToTs(string inputPath, string outputPath)
        {
            IMediaInfo info = FFmpeg.GetMediaInfo(inputPath).GetAwaiter().GetResult();

            IStream videoStream = info.VideoStreams.FirstOrDefault()
                                      ?.SetCodec(VideoCodec.mpeg2video);
            IStream audioStream = info.AudioStreams.FirstOrDefault()
                                      ?.SetCodec(AudioCodec.mp2);

            return New()
                .AddStream(videoStream, audioStream)
                .SetOutput(outputPath);
        }

        /// <summary>
        ///     Convert file to OGV
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <returns>Conversion result</returns>
        internal static IConversion ToOgv(string inputPath, string outputPath)
        {
            IMediaInfo info = FFmpeg.GetMediaInfo(inputPath).GetAwaiter().GetResult();

            IStream videoStream = info.VideoStreams.FirstOrDefault()
                                      ?.SetCodec(VideoCodec.theora);
            IStream audioStream = info.AudioStreams.FirstOrDefault()
                                      ?.SetCodec(AudioCodec.libvorbis);

            return New()
                .AddStream(videoStream, audioStream)
                .SetOutput(outputPath);
        }

        /// <summary>
        ///     Convert file to WebM
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <returns>Conversion result</returns>
        internal static IConversion ToWebM(string inputPath, string outputPath)
        {
            IMediaInfo info = FFmpeg.GetMediaInfo(inputPath).GetAwaiter().GetResult();

            IStream videoStream = info.VideoStreams.FirstOrDefault()
                                      ?.SetCodec(VideoCodec.vp8);
            IStream audioStream = info.AudioStreams.FirstOrDefault()
                                      ?.SetCodec(AudioCodec.libvorbis);

            return New()
                .AddStream(videoStream, audioStream)
                .SetOutput(outputPath);
        }

        /// <summary>
        ///     Convert image video stream to gif
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Output path</param>
        /// <param name="loop">Number of repeats</param>
        /// <param name="delay">Delay between repeats (in seconds)</param>
        /// <returns>Conversion result</returns>
        internal static IConversion ToGif(string inputPath, string outputPath, int loop, int delay = 0)
        {
            IMediaInfo info = FFmpeg.GetMediaInfo(inputPath).GetAwaiter().GetResult();

            IVideoStream videoStream = info.VideoStreams.FirstOrDefault()
                                           ?.SetLoop(loop, delay);

            return New()
                .AddStream(videoStream)
                .SetOutput(outputPath);
        }
    }
}
