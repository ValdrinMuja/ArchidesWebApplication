<script type="text/javascript">
    $(document).ready(function () {
        $('#addUser').bootstrapValidator({
            fields: {
                Username: {
                    selector: '.User',
                    message: 'Name not valid',
                    validators: {
                        notEmpty: {
                            message:'Name cannot be empty'
                        },
                        stringLength: {
                            min: 6,
                            max: 12,
                            message:'Name will be 6 to 12 words'
                        }
                    }
                }
            }
        })
    })
</script>