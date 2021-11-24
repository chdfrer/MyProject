<!--Kích hoạt phần tử #htmlElement là Editor HTML -->

<script src="@Url.Content("~/summernote/summernote-bs4.js")"></script>
<link href="@Url.Content("~/summernote/summernote-bs4.min.css")" rel="stylesheet">

<script>
    $(document).ready(function() {
        $('#htmlElement').summernote({
            height: 200,
            toolbar: [
                // [groupName, [list of button]]
                ['style', ['bold', 'italic', 'underline', 'clear']],
                ['font', ['strikethrough', 'superscript', 'subscript']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['height', ['height']]
                ]
        });
    });
</script>