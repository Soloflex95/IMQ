// File upload drag-and-drop helper
window.fileUploadHelper = {
    initialize: function (dropZoneId, inputFileId) {
        const dropZoneElement = document.getElementById(dropZoneId);
        const inputFileElement = document.getElementById(inputFileId);
        
        if (!dropZoneElement || !inputFileElement) {
            console.error('Drop zone or input file element not found', dropZoneId, inputFileId);
            return;
        }

        console.log('Initializing drag-drop for', dropZoneId, inputFileId);

        // Prevent default drag behaviors on the drop zone
        ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
            dropZoneElement.addEventListener(eventName, preventDefaults, false);
        });
        
        // Prevent default on body to stop browser from opening files
        ['dragenter', 'dragover', 'drop'].forEach(eventName => {
            document.body.addEventListener(eventName, preventDefaults, false);
        });

        function preventDefaults(e) {
            e.preventDefault();
            e.stopPropagation();
        }

        // Highlight drop zone when dragging over it
        dropZoneElement.addEventListener('dragenter', function (e) {
            dropZoneElement.classList.add('drag-over');
        });

        dropZoneElement.addEventListener('dragleave', function (e) {
            // Only remove highlight if we're actually leaving the drop zone
            // (not just entering a child element)
            if (e.target === dropZoneElement) {
                dropZoneElement.classList.remove('drag-over');
            }
        });

        // Handle drop
        dropZoneElement.addEventListener('drop', function (e) {
            console.log('Drop event triggered', e.dataTransfer.files);
            dropZoneElement.classList.remove('drag-over');
            
            const files = e.dataTransfer.files;
            if (files.length > 0) {
                // Trigger the InputFile component with the dropped files
                const dataTransfer = new DataTransfer();
                dataTransfer.items.add(files[0]); // Only take first file
                inputFileElement.files = dataTransfer.files;
                
                // Trigger change event to notify Blazor InputFile component
                const event = new Event('change', { bubbles: true });
                inputFileElement.dispatchEvent(event);
                console.log('File added and change event dispatched');
            }
        });
    }
};
