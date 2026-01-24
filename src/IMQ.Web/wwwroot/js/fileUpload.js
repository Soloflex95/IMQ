// File upload drag-and-drop helper
window.fileUploadHelper = {
    initialize: function (dropZoneElement, inputFileElement) {
        if (!dropZoneElement || !inputFileElement) return;

        // Prevent default drag behaviors on the drop zone
        ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
            dropZoneElement.addEventListener(eventName, preventDefaults, false);
            document.body.addEventListener(eventName, preventDefaults, false);
        });

        function preventDefaults(e) {
            e.preventDefault();
            e.stopPropagation();
        }

        // Handle drop
        dropZoneElement.addEventListener('drop', function (e) {
            const files = e.dataTransfer.files;
            if (files.length > 0) {
                // Trigger the InputFile component with the dropped files
                const dataTransfer = new DataTransfer();
                dataTransfer.items.add(files[0]); // Only take first file
                inputFileElement.files = dataTransfer.files;
                
                // Trigger change event to notify Blazor InputFile component
                const event = new Event('change', { bubbles: true });
                inputFileElement.dispatchEvent(event);
            }
        });
    }
};
