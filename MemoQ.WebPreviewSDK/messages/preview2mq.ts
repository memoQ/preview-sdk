import { FocusedRange } from "./common";

//  Messages originated from teh preview tool
export const enum PreviewMessageType {
  // Register = "Register",
  // Connect = "Connect",
  ChangeHighlightInMQ = "ChangeHighlightInMQ",
  PreviewConfigResponse = "PreviewConfigResponse",
  ContentUpdateRequest = "ContentUpdateRequest",
  PreviewPartIdUpdateRequest = "PreviewPartIdUpdateRequest"
}

export interface PreviewMessage<T> {
  readonly type: PreviewMessageType;
  readonly previewToolId: string;
  readonly params: T;
}

export interface ChangeHighlightInMQParams {
  readonly previewPartId: string;
  readonly sourceLangCode?: string;
  readonly targetLangCode?: string;
  readonly sourceContent?: string;
  readonly targetContent?: string;
  readonly sourceFocusedRange?: FocusedRange;
  readonly targetFocusedRange?: FocusedRange;
}

export interface ContentUpdateRequestParams {
  readonly previewPartIds: string[];
  readonly targetLangCodes: string[];
}

export interface PreviewPartIdUpdateRequestParams {
}

export interface PreviewConfigResponseParams {
  readonly previewToolName: string;
  readonly previewToolDescription: string;
  readonly previewPartIdRegex: string;
  readonly complexity: ContentComplexityLevel;
}

export const enum ContentComplexityLevel {
  Minimal = "Minimal",
  PlainWithInterpretedFormatting = "PlainWithInterpretedFormatting"
}

export interface ContentUpdateRequestMessage
  extends PreviewMessage<ContentUpdateRequestParams> {
  type: PreviewMessageType.ContentUpdateRequest;
}

export interface PreviewPartIdUpdateRequestMessage
  extends PreviewMessage<PreviewPartIdUpdateRequestParams> {
  type: PreviewMessageType.PreviewPartIdUpdateRequest;
}

export interface ChangeHighlightInMQMessage
  extends PreviewMessage<ChangeHighlightInMQParams> {
  type: PreviewMessageType.ChangeHighlightInMQ;
}

export interface PreviewConfigResponseMessage
  extends PreviewMessage<PreviewConfigResponseParams> {
  type: PreviewMessageType.PreviewConfigResponse;
}

export type AnyPreviewMessageParams =
  | ContentUpdateRequestParams
  | PreviewPartIdUpdateRequestParams
  | ChangeHighlightInMQParams
  | PreviewConfigResponseParams;

export type AnyPreviewMessage =
  | ContentUpdateRequestMessage
  | PreviewPartIdUpdateRequestMessage
  | ChangeHighlightInMQMessage
  | PreviewConfigResponseMessage;
