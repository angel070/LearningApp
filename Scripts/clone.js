

    $('a#add-more').cloneData({
        mainContainerId: 'main-container', // Main container Should be ID
    cloneContainer: 'container-item', // Which you want to clone
    removeButtonClass: 'remove-item', // Remove button for remove cloned HTML
    removeConfirm: true, // default true confirm before delete clone item
    removeConfirmMessage: 'Are you sure want to delete?', // confirm delete message
        //append: '<a href="javascript:void(0)" class="remove-item btn btn-sm btn-danger remove-social-media">Remove</a>', // Set extra HTML append to clone HTML
    minLimit: 1, // Default 1 set minimum clone HTML required
    maxLimit: 30, // Default unlimited or set maximum limit of clone HTML
    defaultRender: 1,
    init: function () {
        console.info(':: Initialize Plugin ::');
        },
    beforeRender: function () {
        console.info(':: Before rendered callback called');
        },
    afterRender: function () {
        console.info(':: After rendered callback called');
            //$(".selectpicker").selectpicker('refresh');
        },
    afterRemove: function () {
        console.warn(':: After remove callback called');
        },
    beforeRemove: function () {
        console.warn(':: Before remove callback called');
        }

    });
 
        $(document).ready(function(){
		//group add limit
		var maxGroup = 5000;
        //add more fields group
        $(".addMore").click(function(){
			if($('body').find('.fieldGroup').length < maxGroup){
				var fieldHTML = '<div class="form-group fieldGroup">'+$(".fieldGroupCopy").html()+'</div>';
                $('body').find('.fieldGroup:last').after(fieldHTML);
			        }else{
                    alert('Maximum ' + maxGroup + ' groups are allowed.');
			}
		});
        //remove fields group
        $("body").on("click",".remove",function(){
            $(this).parents(".fieldGroup").remove();
		});
	});
 

