import {
  ChangeHighlightInMQParams,
  ContentUpdateRequestParams,
  PreviewPartIdUpdateRequestParams,
  PreviewMessageType,
  PreviewMessage,
  ContentUpdateParams,
  MQMessageType,
  ChangeHighlightInPreviewParams,
  AnyMQMessageParams,
  AnyMQMessage,
  ContentComplexityLevel
} from "./messages";

declare const mqCallback: { callbackFunc(value: object): void; };

export default class MQ {
  constructor(
    private previewToolId: string,
    private previewToolName: string,
    private previewToolDescription: string,
    private previewPartIdRegex: string,
    private complexity: ContentComplexityLevel
  ) {
    this.handlePreviewConfigRequested();
  }

  changeHighlight(params: ChangeHighlightInMQParams) {
    this.sendPreviewToolMessage(PreviewMessageType.ChangeHighlightInMQ, params);
  }

  requestContentUpdate(params: ContentUpdateRequestParams) {
    this.sendPreviewToolMessage(
      PreviewMessageType.ContentUpdateRequest,
      params
    );
  }

  requestPreviewPartIdUpdate(params: PreviewPartIdUpdateRequestParams) {
    this.sendPreviewToolMessage(
      PreviewMessageType.PreviewPartIdUpdateRequest,
      params
    );
  }

  private createPreviewToolMessage<T>(
    type: PreviewMessageType,
    params: T
  ): PreviewMessage<T> {
    return {
      type,
      previewToolId: this.previewToolId,
      params
    } as PreviewMessage<T>;
  }

  private sendPreviewToolMessage<T>(type: PreviewMessageType, params: T): void {
    let message = this.createPreviewToolMessage(type, params);
    mqCallback.callbackFunc(message);
  }

  onContentUpdated(handler: (params: ContentUpdateParams) => void) {
    this.handleMQMessage(MQMessageType.ContentUpdate, handler);
  }

  onHighlightChanged(
    handler: (params: ChangeHighlightInPreviewParams) => void
  ) {
    this.handleMQMessage(MQMessageType.ChangeHighlightInPreview, handler);
  }

  private handlePreviewConfigRequested() {
    this.handleMQMessage(MQMessageType.PreviewConfigRequest, () => {
      this.sendPreviewToolMessage(PreviewMessageType.PreviewConfigResponse, {
        previewToolName: this.previewToolName,
        previewToolDescription: this.previewToolDescription,
        previewPartIdRegex: this.previewPartIdRegex,
        complexity: this.complexity
      });
    });
  }

  private handleMQMessage(
    messageType: MQMessageType,
    handler: (params: AnyMQMessageParams) => void
  ) {
    window.addEventListener("message", event => {
      let message = <AnyMQMessage>event.data;
      if (message.type === messageType) {
        handler(message.params);
      }
    });
  }
}
