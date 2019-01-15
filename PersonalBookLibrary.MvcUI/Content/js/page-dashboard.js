$(function() {

	"use strict";

	// Knob plugin
	$(".js-knob").knob();

	// Sparklines plugin
	$('.spark-bar').sparkline('html', {
		type: 'bar',
		height: '45px',
		barColor: '#d2d2d2',
		barWidth: 10
	});

	// Tasks
	$('.panel-tasks input').click(function(e){
		$(this).parent().toggleClass('task-done');
	});
})