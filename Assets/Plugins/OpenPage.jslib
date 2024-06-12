  var iframe;
mergeInto(LibraryManager.library, {
   
 OpenWebPageInImage: function(url, x, y, width, height) {
         iframe = document.createElement('iframe');
         iframe.id = UTF8ToString('iframe');
 window.addEventListener('resize', function() {
            if (iframe.style.display === 'block') {
            var canvas = document.getElementById('unity-canvas');  // ID for the Unity canvas
            var rect = canvas.getBoundingClientRect();
            iframe.style.left = rect.left + 'px';
            iframe.style.top = rect.top + 'px';
            iframe.style.width = rect.width + 'px';
            iframe.style.height = rect.height + 'px';
             iframe.style.position = 'absolute';
              iframe.style.zIndex = 10000; 
           
              

                }
            });
            
        iframe.src = UTF8ToString(url);
        iframe.style.position = 'absolute';
        iframe.style.left = x + 'px';
        iframe.style.top = y + 'px';
        iframe.style.width = width + 'px';
        iframe.style.height = height + 'px';
        iframe.style.border = 'none';
        iframe.allowFullscreen = true;
iframe.webkitAllowFullScreen = true;
iframe.mozAllowFullScreen = true;
          iframe.style.zIndex = 10000;  // Ensure it is above the canvas



        document.body.appendChild(iframe);
      

       
          // Load html2canvas library dynamically
        var script = document.createElement('script');
       // script.src = 'https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js';
       script.src = 'https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.min.js';




        script.onload = function () {
            console.log('html2canvas loaded');
        };
        document.head.appendChild(script);
        setInterval(function() {
           if(iframe.style.display == 'none')
           {
            var canvas = document.getElementById('unity-canvas');
             canvas.style.display = 'none';
            iframe.style.display = 'block';
           }
           
           else
           if(iframe.style.display == 'block')
           {
            iframe.style.display = 'none';
            var canvas = document.getElementById('unity-canvas');
             canvas.style.display = 'block';
           }
          
           
        }, 6000);


    },
HideWebPageInImage: function() {
        if (iframe) {
            iframe.style.display = 'none';
        }
    },

    ShowWebPageInImage: function() {
        if (iframe) {
            iframe.style.display = 'block';
        }
    },

    RemoveWebPageInImage: function() {
        if (iframe) {
            document.body.removeChild(iframe);
            iframe = null;
        }
    },
 UpdateIframePositionAndSize: function() {
        if (iframe) {
            var canvas = document.getElementById('unity-canvas');  // ID for the Unity canvas
            var rect = canvas.getBoundingClientRect();
           iframe.style.left = rect.left + 'px';
            iframe.style.top = rect.top + 'px';
            iframe.style.width = rect.width + 'px';
            iframe.style.height = rect.height + 'px';
             
              iframe.style.position = 'absolute';
              iframe.style.zIndex = 10000; 
               

        }
    },
    captureIframeAsImage: function(iframeId) {
      
        var iframeDocument = iframe.contentDocument || iframe.contentWindow.document;

        html2canvas(iframeDocument.body).then(function(canvas) {
         var dataURL = canvas.toDataURL('image/png');
            // Send the base64 image data to Unity
            SendMessage('IframeController', 'ReceiveImageData', dataURL);
        });
    },

    startIframeCapture: function(iframeId, interval) {
        var iframeIdStr = UTF8ToString(iframeId);
        setInterval(function() {
           
            var iframeDocument = iframe.contentDocument || iframe.contentWindow.document;
            
            html2canvas(iframeDocument.body).then(function(canvas) {
                var dataURL = canvas.toDataURL('image/png');
                // Send the base64 image data to Unity
                SendMessage('IframeController', 'ReceiveImageData', dataURL);
            });
        }, interval);
    }

});