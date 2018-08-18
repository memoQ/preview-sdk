import { FocusedRange, PreviewPart } from "./common";

//  messages originated from MQ client
export const enum MQMessageType {
  PreviewConfigRequest = "PreviewConfigRequest", //  annak az esetnek a támogatására, ha a wrapper tool nem tartalmazná beállításként a web preview config-ot, hanem a web preview-tol kérné le
  ChangeHighlightInPreview = "ChangeHighlightInPreview",
  ContentUpdate = "ContentUpdate" //  ez ugye nem csak contentupdaterequest-re jöhet, hanem magától is,ha a mq-ban megváltozik a tartalom
}

interface MQMessage<T> {
  readonly type: MQMessageType;
  readonly params: T;
}

export interface ContentUpdateParams {
  readonly previewParts: PreviewPart[];
}

export interface PreviewPartWithFocusedRange extends PreviewPart {
  readonly sourceFocusedRange: FocusedRange;
  readonly targetFocusedRange: FocusedRange;
}

export interface ChangeHighlightInPreviewParams {
  readonly activePreviewParts: PreviewPartWithFocusedRange[];
}

export type AnyMQMessageParams =
  | ContentUpdateParams
  | ChangeHighlightInPreviewParams
  | void;

export interface ContentUpdateMessage extends MQMessage<ContentUpdateParams> {
  type: MQMessageType.ContentUpdate;
}

export interface ChangeHighlightInPreviewMessage
  extends MQMessage<ChangeHighlightInPreviewParams> {
  type: MQMessageType.ChangeHighlightInPreview;
}

export interface PreviewConfigRequestMessage extends MQMessage<void> {
  type: MQMessageType.PreviewConfigRequest;
}

export type AnyMQMessage =
  | ContentUpdateMessage
  | ChangeHighlightInPreviewMessage
  | PreviewConfigRequestMessage;
