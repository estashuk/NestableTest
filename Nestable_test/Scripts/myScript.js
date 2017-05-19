    $(document).ready(function() {
        var updateOutput = function(e) {
            var list = e.length ? e : $(e.target),
                output = list.data('output');
            if (window.JSON) {
                output.val(window.JSON.stringify(list.nestable('serialize'))); //, null, 2));
                $.ajax({
                    url: "/Home/SaveMenuConfiguration",
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    data: JSON.stringify({
                        txtValue: $("#nestable-output").val()
                    }),
                    async: true
                });
            } else {
                output.val('JSON browser support required for this demo.');
            };
        };

        // activate Nestable for list 1
        $('#nestable').nestable({
            group: 1
        }).on('change', updateOutput);

        // activate Nestable for list 2
        $('#nestable2').nestable({
            group: 1
        }).on('change', updateOutput);

        // output initial serialised data
        updateOutput($('#nestable').data('output', $('#nestable-output')));
        updateOutput($('#nestable2').data('output', $('#nestable2-output')));

        $('#nestable-menu').on('click', function(e) {
            var target = $(e.target),
                action = target.data('action');
            if (action === 'expand-all') {
                $('.dd').nestable('expandAll');
            }
            if (action === 'collapse-all') {
                $('.dd').nestable('collapseAll');
            }
        });

        //$('#nestable3').nestable();
    });

    $(function () {
        $('#btnSaveMenuCfg').unbind('click');
        $('#btnSaveMenuCfg').on('click', function () {
            $.ajax({
                url: "/Home/SaveMenuConfiguration",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: JSON.stringify({
                    txtValue: $("#nestable-output").val()
                }),
                async: false
            });
        });
    });