﻿$(function () {
    $('#deleteform').submit(function () {
        return confirm('Are you sure you want to delete? This action cannot be undone!');
    });
});