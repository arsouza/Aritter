'use strict';

module.exports = function (grunt) {

  require('load-grunt-tasks')(grunt);

  //var changeLog = grunt.file.read('../CHANGELOG.md');
  //grunt.log.writeln([changeLog]);

  grunt.initConfig({
    jshint: {
      options: {
        jshintrc: '.jshintrc'
      },
      sourceCode: ['wwwroot/app.module.js', 'wwwroot/app/**/*.js']
    }
  });

};
