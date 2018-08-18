export interface PreviewPart {
  readonly previewPartId: string;
  readonly sourceLangCode: string;
  readonly targetLangCode: string;
  readonly sourceContent: string;
  readonly targetContent: string;
}

export interface FocusedRange {
  readonly startIndex: number;
  readonly length: number;
}
