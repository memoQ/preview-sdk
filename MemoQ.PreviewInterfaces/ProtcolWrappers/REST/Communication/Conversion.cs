using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication
{
    internal static class Conversion
    {
        public static Model.RegistrationRequest Convert(this Entities.RegistrationRequest request)
        {
            return new Model.RegistrationRequest()
            {
                PreviewToolId = request.PreviewToolId,
                PreviewToolName = request.PreviewToolName,
                PreviewToolDescription = request.PreviewToolDescription,
                AutoStartupCommand = request.AutoStartupCommand,
                PreviewPartIdRegex = request.PreviewPartIdRegex,
                RequiresWebPreviewBaseUrl = request.RequiresWebPreviewBaseUrl,
                ContentComplexity = request.ContentComplexity.Convert(),
                RequiredProperties = request.RequiredProperties
            };
        }

        public static Model.ContentComplexityLevel Convert(this Entities.ContentComplexityLevel contentComplexityLevel)
        {
            switch (contentComplexityLevel)
            {
                case Entities.ContentComplexityLevel.Minimal:
                    return Model.ContentComplexityLevel.Minimal;
                case Entities.ContentComplexityLevel.PlainWithInterpretedFormatting:
                    return Model.ContentComplexityLevel.PlainWithInterpretedFormatting;
                default:
                    throw new Exception($"Unexpected complexity level: {contentComplexityLevel}.");
            }
        }

        public static Model.ChangeRuntimeSettingsRequest Convert(this Entities.ChangeRuntimeSettingsRequest request)
        {
            return new Model.ChangeRuntimeSettingsRequest()
            {
                ContentComplexity = request.ContentComplexity.Convert(),
                RequiredProperties = request.RequiredProperties
            };
        }

        public static Model.ChangeHighlightRequestFromPreviewTool Convert(this Entities.ChangeHighlightRequestFromPreviewTool request)
        {
            return new Model.ChangeHighlightRequestFromPreviewTool()
            {
                PreviewPartId = request.PreviewPartId,
                SourceLangCode = request.SourceLangCode,
                TargetLangCode = request.TargetLangCode,
                SourceContent = request.SourceContent,
                TargetContent = request.TargetContent,
                SourceFocusedRange = request.SourceFocusedRange == null ? null : request.SourceFocusedRange.Convert(),
                TargetFocusedRange = request.TargetFocusedRange == null ? null : request.TargetFocusedRange.Convert()
            };
        }

        public static Model.FocusedRange Convert(this Entities.FocusedRange focusedRange)
        {
            return new Model.FocusedRange()
            {
                StartIndex = focusedRange.StartIndex,
                Length = focusedRange.Length
            };
        }

        public static Entities.ContentUpdateRequestFromMQ Convert(this Model.ContentUpdateRequestFromMQ request)
        {
            return new Entities.ContentUpdateRequestFromMQ(request.PreviewParts.Select(p => p.Convert()).ToArray());
        }

        public static Entities.PreviewPart Convert(this Model.PreviewPart previewPart)
        {
            return new Entities.PreviewPart(
                previewPart.PreviewPartId,
                previewPart.PreviewProperties.Select(p => p.Convert()).ToArray(),
                previewPart.SourceDocument.Convert(),
                previewPart.SourceLangCode,
                previewPart.TargetLangCode,
                previewPart.SourceContent.Convert(),
                previewPart.TargetContent.Convert());
        }

        public static Entities.PreviewPartWithFocusedRange Convert(this Model.PreviewPartWithFocusedRange previewPart)
        {
            return new Entities.PreviewPartWithFocusedRange(
                previewPart.PreviewPartId,
                previewPart.PreviewProperties.Select(p => p.Convert()).ToArray(),
                previewPart.SourceDocument.Convert(),
                previewPart.SourceLangCode,
                previewPart.TargetLangCode,
                previewPart.SourceContent.Convert(),
                previewPart.TargetContent.Convert(),
                previewPart.SourceFocusedRange == null ? null : previewPart.SourceFocusedRange.Convert(),
                previewPart.TargetFocusedRange == null ? null : previewPart.TargetFocusedRange.Convert());
        }

        public static Entities.FocusedRange Convert(this Model.FocusedRange focusedRange)
        {
            return new Entities.FocusedRange(focusedRange.StartIndex, focusedRange.Length);
        }

        public static Entities.PreviewProperty Convert(this Model.PreviewProperty previewProperty)
        {
            return new Entities.PreviewProperty(previewProperty.Name, previewProperty.Value);
        }

        public static Entities.SourceDocument Convert(this Model.SourceDocument sourceDocument)
        {
            return new Entities.SourceDocument(sourceDocument.DocumentGuid, sourceDocument.DocumentName, sourceDocument.ImportPath);
        }

        public static Entities.PreviewContent Convert(this Model.PreviewContent previewContent)
        {
            return new Entities.PreviewContent(
                previewContent.Complexity.Convert(),
                previewContent.Content);
        }

        public static Entities.ContentComplexityLevel Convert(this Model.ContentComplexityLevel contentComplexityLevel)
        {
            switch (contentComplexityLevel)
            {
                case Model.ContentComplexityLevel.Minimal:
                    return Entities.ContentComplexityLevel.Minimal;
                case Model.ContentComplexityLevel.PlainWithInterpretedFormatting:
                    return Entities.ContentComplexityLevel.PlainWithInterpretedFormatting;
                default:
                    throw new Exception($"Unexpected complexity level: {contentComplexityLevel}.");
            }
        }

        public static Entities.ChangeHighlightRequestFromMQ Convert(this Model.ChangeHighlightRequestFromMQ request)
        {
            return new Entities.ChangeHighlightRequestFromMQ(request.ActivePreviewParts.Select(p => p.Convert()).ToArray());
        }

        public static Entities.PreviewPartIdUpdateRequestFromMQ Convert(this Model.PreviewPartIdUpdateRequestFromMQ request)
        {
            return new Entities.PreviewPartIdUpdateRequestFromMQ(request.PreviewPartIds);
        }
    }
}
