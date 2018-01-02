﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Xabe.FFmpeg.Enums;

namespace Xabe.FFmpeg
{
    /// <summary>
    ///     Derives preconfigurated Configuration objects
    /// </summary>
    public static class ConversionHelper
    {
        /// <summary>
        ///     Convert file to MP4
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <param name="speed">Conversion speed</param>
        /// <param name="size">Dimension</param>
        /// <param name="audioQuality">Audio quality</param>
        /// <param name="multithread">Use multithread</param>
        /// <returns>Conversion result</returns>
        public static IConversion ToMp4(string inputPath, string outputPath, Speed speed = Speed.SuperFast,
            VideoSize size = null, AudioQuality audioQuality = AudioQuality.Normal, bool multithread = true)
        {
            IMediaInfo info = MediaInfo.Get(inputPath)
                                       .Result;

            IVideoStream videoStream = info.VideoStreams.FirstOrDefault()
                                           ?.SetScale(size)
                                           ?.SetCodec(VideoCodec.h264, 2400);

            IAudioStream audioStream = info.AudioStreams.FirstOrDefault()
                                           ?.SetAudio(AudioCodec.aac, audioQuality);

            return Conversion.New()
                             .AddVideoStream(videoStream)
                             .AddAudioStream(audioStream)
                             .UseMultiThread(multithread)
                             .SetSpeed(speed)
                             .SetOutput(outputPath);
        }

        /// <summary>
        ///     Convert file to TS
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <returns>Conversion result</returns>
        public static IConversion ToTs(string inputPath, string outputPath)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .StreamCopy(Channel.Both)
            //                 .SetBitstreamFilter(Channel.Video, BitstreamFilter.H264_Mp4ToAnnexB)
            //                 .SetFormat(VideoFormat.mpegts)
            //                 .SetOutput(outputPath);

            throw new NotImplementedException();
        }


        /// <summary>
        ///     Convert file to WebM
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <param name="size">Dimension</param>
        /// <param name="audioQuality">Audio quality</param>
        /// <param name="multithread">Use multithread</param>
        /// <returns>Conversion result</returns>
        public static IConversion ToWebM(string inputPath, string outputPath, VideoSize size = null, AudioQuality audioQuality = AudioQuality.Normal, bool multithread = false)
        {
            //return Conversion.New()
            //    .SetInput(inputPath)
            //    .SetScale(size)
            //    .SetCodec(VideoCodec.vp8, 2400)
            //    .SetAudio(AudioCodec.libvorbis, audioQuality)
            //    .SetOutput(outputPath)
            //    .UseMultiThread(multithread);

            throw new NotImplementedException();
        }


        /// <summary>
        ///     Convert file to OGV
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="outputPath">Destination file</param>
        /// <param name="size">Dimension</param>
        /// <param name="audioQuality">Audio quality</param>
        /// <param name="multithread">Use multithread</param>
        /// <returns>Conversion result</returns>
        public static IConversion ToOgv(string inputPath, string outputPath, VideoSize size = null, AudioQuality audioQuality = AudioQuality.Normal, bool multithread = false)
        {
            //return Conversion.New()
            //    .SetInput(inputPath)
            //    .SetScale(size)
            //    .SetCodec(VideoCodec.theora, 2400)
            //    .SetSpeed(16)
            //    .SetAudio(AudioCodec.libvorbis, audioQuality)
            //    .SetOutput(outputPath);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Change video size
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="output">Output path</param>
        /// <param name="size">Expected size</param>
        /// <returns>Conversion result</returns>
        public static IConversion ChangeSize(string inputPath, string output, VideoSize size)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .SetScale(size)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Add subtitle to file. It will be added as new stream so if you want to burn subtitles into video you should use
        ///     SetSubtitles method.
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="output">Output path</param>
        /// <param name="subtitlePath">Path to subtitle file in .srt format</param>
        /// <param name="language">Language code in ISO 639. Example: "eng", "pol", "pl", "de", "ger"</param>
        /// <returns>Conversion result</returns>
        public static IConversion AddSubtitle(string inputPath, string output, string subtitlePath, string language)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .AddSubtitle(subtitlePath, language)
            //                 .StreamCopy(Channel.Both)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Burn subtitle into video. If you want to add subtitle as new stream (like in .mkv) you should use AddSubtitle
        ///     method.
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="output">Output path</param>
        /// <param name="subtitlePath">Path to subtitle file in .srt format</param>
        /// <returns>Conversion result</returns>
        public static IConversion BurnSubtitle(string inputPath, string output, string subtitlePath)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .SetSubtitle(subtitlePath)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Extract video from file
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="output">Output audio stream</param>
        /// <returns>Conversion result</returns>
        public static IConversion ExtractVideo(string inputPath, string output)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .StreamCopy(Channel.Both)
            //                 .DisableChannel(Channel.Audio)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }


        /// <summary>
        ///     Melt watermark into video
        /// </summary>
        /// <param name="inputPath">Input video path</param>
        /// <param name="position">Position of watermark</param>
        /// <param name="output">Output file</param>
        /// <param name="inputImage">Watermark</param>
        /// <returns>Conversion result</returns>
        public static IConversion SetWatermark(string inputPath, string inputImage, Position position, string output)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .SetWatermark(inputImage, position)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Extract audio from file
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="output">Output video stream</param>
        /// <returns>Conversion result</returns>
        public static IConversion ExtractAudio(string inputPath, string output)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .DisableChannel(Channel.Video)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Convert image video stream to gif
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="output">Output path</param>
        /// <param name="loop">Number of repeats</param>
        /// <param name="delay">Delay between repeats (in seconds)</param>
        /// <returns>Conversion result</returns>
        public static IConversion ToGif(string inputPath, string output, int loop, int delay = 0)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .SetLoop(1, delay)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Add audio to file
        /// </summary>
        /// <param name="inputPath">Input path</param>
        /// <param name="audioFilePath">Audio file</param>
        /// <param name="output">Output file</param>
        /// <returns>Conversion result</returns>
        public static IConversion AddAudio(string inputPath, string audioFilePath, string output)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath, audioFilePath)
            //                 .StreamCopy(Channel.Video)
            //                 .SetAudio(AudioCodec.aac, AudioQuality.Hd)
            //                 .SetOutput(output);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Saves snapshot of video
        /// </summary>
        /// <param name="inputPath">Video</param>
        /// <param name="outputPath">Output file</param>
        /// <param name="size">Dimension of snapshot</param>
        /// <param name="captureTime"></param>
        /// <returns>Conversion result</returns>
        public static IConversion Snapshot(string inputPath, string outputPath, VideoSize size = null, TimeSpan? captureTime = null)
        {
            //IMediaInfo source = MediaInfo.Get(inputPath)
            //                                       .Result;
            //if (captureTime == null)
            //    captureTime = TimeSpan.FromSeconds(source.VideoDuration.TotalSeconds / 3);

            //todo: snapshot is video stream feature

            //size = GetSize(source, size);

            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .SetCodec(VideoCodec.png)
            //                 .SetOutputFramesCount(1)
            //                 .SetSeek(captureTime)
            //                 .SetSize(size)
            //                 .SetOutput(outputPath);

            throw new NotImplementedException();

        }

        /// <summary>
        ///     Records M3U8 streams to the specified output.
        /// </summary>
        /// <param name="uri">URI to stream.</param>
        /// <param name="outputPath">Output file</param>
        /// <returns>Conversion result</returns>
        public static IConversion SaveM3U8Stream(Uri uri, string outputPath)
        {
            //if(uri.Scheme != "http" ||
            //   uri.Scheme != "https")
            //    throw new ArgumentException($"Invalid uri {uri.AbsolutePath}");

            //return Conversion.New()
            //                 .SetInput(uri)
            //                 .SetOutput(outputPath);

            throw new NotImplementedException();


        }

        /// <summary>
        ///     Concat multiple inputVideos.
        /// </summary>
        /// <param name="output">Concatenated inputVideos</param>
        /// <param name="inputVideos">Videos to add</param>
        /// <returns>Conversion result</returns>
        public static async Task<bool> Concatenate(string output, params string[] inputVideos)
        {
            //if(inputVideos.Length <= 1)
            //    throw new ArgumentException("You must provide at least 2 files for the concatenation to work", "inputVideos");

            //var mediaInfos = new List<IMediaInfo>();

            //var conversion = Conversion.New();
            //foreach (string inputVideo in inputVideos)
            //{
            //    mediaInfos.Add(await MediaInfo.Get(inputVideo));
            //    conversion.AddParameter($"-i \"{inputVideo}\" ");
            //}
            //conversion.AddParameter($"-t 1 -f lavfi -i anullsrc=r=48000:cl=stereo");
            //conversion.AddParameter($"-filter_complex \"");

            //MediaProperties maxResolutionMedia = mediaInfos.OrderByDescending(x => x.Width)
            //                                         .First().Properties;
            //for(var i = 0; i < mediaInfos.Count; i++)
            //{
            //        conversion.AddParameter(
            //            $"[{i}:v]scale={maxResolutionMedia.Width}:{maxResolutionMedia.Height},setdar=dar={maxResolutionMedia.Ratio},setpts=PTS-STARTPTS[v{i}]; ");
            //}

            //for(var i = 0; i < mediaInfos.Count; i++)
            //{
            //    if(string.IsNullOrEmpty(mediaInfos[i].AudioFormat))
            //        conversion.AddParameter($"[v{i}][{mediaInfos.Count}:a]");
            //    else
            //        conversion.AddParameter($"[v{i}][{i}:a]");
            //}

            //conversion.AddParameter($"concat=n={inputVideos.Length}:v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\"");
            //conversion.SetOutput(output);
            //return await conversion.Start();
            //todo: implementantion

            throw new NotImplementedException();
        }

        private static VideoSize GetSize(IMediaInfo source, VideoSize size)
        {
            //if(size == null ||
            //   size. Height == 0 && size.Width == 0)
            //    size = new VideoSize(source.Width, source.Height);

            //if(size.Width != size.Height)
            //{
            //    if(size.Width == 0)
            //    {
            //        double ratio = source.Width / (double) size.Width;

            //        size = new VideoSize((int) (source.Width * ratio), (int) (source.Height * ratio));
            //    }

            //    if(size.Height == 0)
            //    {
            //        double ratio = source.Height / (double) size.Height;

            //        size = new VideoSize((int) (source.Width * ratio), (int) (source.Height * ratio));
            //    }
            //}

            //todo: implementation to video stream class

            return size;
        }

        /// <summary>
        ///     Get part of video
        /// </summary>
        /// <param name="inputPath">Video</param>
        /// <param name="outputPath">Output file</param>
        /// <param name="startTime">Start point</param>
        /// <param name="duration">Duration of new video</param>
        /// <returns></returns>
        public static IConversion Split(string inputPath, TimeSpan startTime, TimeSpan duration, string outputPath)
        {
            //return Conversion.New()
            //                 .SetInput(inputPath)
            //                 .Split(startTime, duration)
            //                 .SetOutput(outputPath);
            throw new NotImplementedException();
        }
    }
}
