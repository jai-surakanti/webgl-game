mergeInto(LibraryManager.library, {

  EndGame: function (userId, score) {
    if (window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.actionCompleted) {
      window.webkit.messageHandlers.actionCompleted.postMessage({
        "status": "success",
        "message": "Action completed successfully",
        "data": {
            "userId": userId,
            "timestamp": Date.now(),
            "score": score
        }
      });
    } else {
      console.warn("WKWebView message handler is not available.");
    }
  },
});