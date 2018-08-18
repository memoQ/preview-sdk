import MQ from "./mq";
import {
  ContentComplexityLevel,
  PreviewPart,
  ChangeHighlightInPreviewParams,
  PreviewPartWithFocusedRange
} from "messages";

let mq = new MQ(
  "24ac39e8-b2ea-4077-a607-671568fcd097",
  "sample-web-preview-tool",
  "this is a sample web preview tool",
  ".*",
  ContentComplexityLevel.Minimal
);

//  Subscribe to MQ's ContentUpdate message
mq.onContentUpdated(content => {
  console.log(content);
  for (const part of content.previewParts) {
    const span = findPreviewSpan(part.previewPartId);
    if (span) {
      span.innerText = part.targetContent || part.sourceContent;
    } else {
      constructDummyDocument(content.previewParts);
      return;
    }
  }
});

//  Subscribe to MQ's HighlightChanged message
mq.onHighlightChanged(params => {
  console.log(params);
  highlightPreviewParts(params);
});

function constructDummyDocument(previewParts: PreviewPart[]) {
  const doc = document.querySelector("#document");
  if (!doc) {
    return;
  }

  clearElement(doc);

  const paragraphFrequency = 5;
  let currentParagraph = document.createElement("p");
  for (let i = 0; i < previewParts.length; i++) {
    if ((i + 1) % paragraphFrequency === 0) {
      doc.appendChild(currentParagraph);
      currentParagraph = document.createElement("p");
    }

    const part = previewParts[i];
    const currentPart = document.createElement("span");
    currentPart.classList.add("preview-segment");
    currentPart.setAttribute("data-id", part.previewPartId);
    currentPart.addEventListener("click", changeHighlight);
    currentPart.innerText = part.targetContent || part.sourceContent;
    currentParagraph.appendChild(currentPart);
  }
  doc.appendChild(currentParagraph);
}

function highlightPreviewParts(params: ChangeHighlightInPreviewParams) {
  clearPreviousHighlights();
  params.activePreviewParts.forEach(highlightPart);
}

function highlightPart(part: PreviewPartWithFocusedRange) {
  const span = findPreviewSpan(part.previewPartId);
  if (!span) {
    return;
  }

  clearElement(span);
  const textWithRange = getTextWithRange(part);

  const start = textWithRange.text.substr(0, textWithRange.range.startIndex);
  const mid = textWithRange.text.substr(
    textWithRange.range.startIndex,
    textWithRange.range.length
  );
  const end = textWithRange.text.substr(
    textWithRange.range.startIndex + textWithRange.range.length
  );

  const highlightedPart = document.createElement("span");
  highlightedPart.classList.add("highlight");
  highlightedPart.innerText = mid;

  span.classList.add("selected");
  span.appendChild(document.createTextNode(start));
  span.appendChild(highlightedPart);
  span.appendChild(document.createTextNode(end));
  span.scrollIntoView({ block: "center", behavior: "smooth" });
}

function changeHighlight(event: Event) {
  const target = event.target as HTMLSpanElement;
  const id = target.getAttribute("data-id");
  if (!id) {
    return;
  }

  mq.changeHighlight({
    previewPartId: id
  });

  const text = target.innerText;
  const range = { startIndex: 0, length: text.length };
  highlightPreviewParts({
    activePreviewParts: [
      {
        previewPartId: id,
        sourceContent: text,
        targetContent: text,
        sourceLangCode: "",
        targetLangCode: "",
        sourceFocusedRange: range,
        targetFocusedRange: range
      }
    ]
  });
}

function findPreviewSpan(id: string) {
  return document.querySelector<HTMLSpanElement>(`span[data-id="${id}"]`);
}

function clearPreviousHighlights() {
  const selectedSpans = document.querySelectorAll<HTMLSpanElement>(".selected");
  for (let i = 0; i < selectedSpans.length; i++) {
    clearPreviousHighlight(selectedSpans[i]);
  }
}

function clearPreviousHighlight(selectedSpan: HTMLSpanElement) {
  const start = selectedSpan.childNodes[0] as Text;
  const mid = selectedSpan.children[0] as HTMLSpanElement;
  const end = selectedSpan.childNodes[2] as Text;

  selectedSpan.classList.remove("selected");
  clearElement(selectedSpan);
  selectedSpan.innerText =
    (start || { wholeText: "" }).wholeText +
    (mid || { innerText: "" }).innerText +
    (end || { innerText: "" }).wholeText;
}

function getTextWithRange(params: PreviewPartWithFocusedRange) {
  if (params.targetContent) {
    return {
      text: params.targetContent,
      range: params.targetFocusedRange
    };
  } else {
    return {
      text: params.sourceContent,
      range: params.sourceFocusedRange
    };
  }
}

function clearElement(element: Element) {
  while (element.lastChild) {
    element.removeChild(element.lastChild);
  }
}
