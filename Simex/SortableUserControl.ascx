<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SortableUserControl.ascx.vb" Inherits="smx.SortableUserControl" %>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>

<style type="text/css">
    #sortable
    {
        list-style-type: none;
        margin: 0;
        padding: 0;
        width: 60%;
    }
    #sortable li
    {
        margin: 0 3px 3px 3px;
        padding: 0.4em;
        padding-left: 1.5em;
        font-size: 1.4em;
        height: 18px;
    }
    #sortable li span
    {
        position: absolute;
        margin-left: -1.3em;
    }
</style>

<script type="text/javascript">
	$(function() {
		$( "#sortable" ).sortable();
		$( "#sortable" ).disableSelection();
	});
</script>

<ul id="sortable">
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        1</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        2</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        3</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        4</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        5</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        6</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item
        7</li>
</ul>