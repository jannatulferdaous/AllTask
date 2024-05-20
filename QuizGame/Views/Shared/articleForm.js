
$(document).ready(function () {
    $("#submit-btn").click(function () {
        var language = $("#language").val();
        var title = $("#title").val();
        var articleText = $("#articleText").val();
        var isValid = true;
        var errorMessage = "";
        if (language.length < 1) {
            isValid = false;
            $("#language-error").html("Language is required.");
        } else {
            $("#language-error").html(""); // Clear error message if language is valid
        }
        if (title.length < 3) {
            isValid = false;
            $("#title-error").html("Title must be at least 3 characters long."); // Set specific error message
        } else {
            $("#title-error").html("");
        }
        if (articleText.length < 50) {
            isValid = false;
            $("#articleText-error").html("Article text must be at least 50 characters long.");
        } else {
            $("#articleText-error").html("");
        }
        tinyMCE.triggerSave();

        if (!isValid) {
            return false;
        }
        $.ajax({
            url: '/Article/Create',
            type: 'POST',
            data: $("#articleForm").serialize(),
            success: function (response) {
                console.log('Article created successfully!');

            },
            error: function (xhr, status, error) {
                console.error('Error creating article:', error);

            }
        });
        return false;
    });
});
