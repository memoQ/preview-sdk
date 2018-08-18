using MemoQ.PreviewInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public static class Extensions
    {
        #region PreviewToolToMQ

        public static ChangeRuntimeSettingsRequest ConvertToChangeRuntimeSettingsRequest(this Dictionary<String, Object> parameters)
        {
            return new ChangeRuntimeSettingsRequest(parameters["complexity"].ToString() == ContentComplexityLevel.Minimal.ToString() ? ContentComplexityLevel.Minimal : ContentComplexityLevel.PlainWithInterpretedFormatting, new string[] { PropertyNames.WebPreviewBaseUrl });
        }

        public static ContentUpdateRequestFromPreviewTool ConvertToContentUpdateRequest(this Dictionary<String, Object> parameters)
        {
            return JsonConvert.DeserializeObject<ContentUpdateRequestFromPreviewTool>(JsonConvert.SerializeObject(parameters));
        }

        public static ChangeHighlightRequestFromPreviewTool ConvertToChangeHighlightRequest(this Dictionary<String, Object> parameters)
        {
            return JsonConvert.DeserializeObject<ChangeHighlightRequestFromPreviewTool>(JsonConvert.SerializeObject(parameters));
        }

        #endregion

        #region MQToPreviewTool

        public static ContentUpdateParams ConvertRequestToContentUpdateParams(this ContentUpdateRequestFromMQ contentUpdateRequest, Regex previewPartIdRegex)
        {
            return new ContentUpdateParams(contentUpdateRequest.PreviewParts.Where(p => previewPartIdRegex.IsMatch(p.PreviewPartId)).Select(p => p.Convert()).ToArray());
        }

        public static ChangeHighlightInPreviewParams ConvertRequestToChangeHighlightParams(this ChangeHighlightRequestFromMQ changeHighlighRequest, Regex previewPartIdRegex)
        {
            var activeParts = changeHighlighRequest.ActivePreviewParts.Where(p => previewPartIdRegex.IsMatch(p.PreviewPartId)).Select(part => new PreviewToolPreviewPartWithFocusedRange
(
                part.PreviewPartId,
                part.SourceLangCode,
                part.TargetLangCode,
                part.SourceContent.Content,
                part.TargetContent.Content,
                part.SourceFocusedRange,
                part.TargetFocusedRange
            )).ToArray();

            return new ChangeHighlightInPreviewParams(activeParts);
        }

        public static PreviewToolPreviewPart Convert(this PreviewPart previewPart)
        {
            return new PreviewToolPreviewPart
            (
                previewPart.PreviewPartId,
                previewPart.SourceLangCode,
                previewPart.TargetLangCode,
                previewPart.SourceContent.Content,
                previewPart.TargetContent.Content
            );
        }

        #endregion
    }
}
