'use strict';

module.exports = function (grunt) {

  require('load-grunt-tasks')(grunt);
  require('rimraf')(grunt);
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-cssmin');
  grunt.loadNpmTasks('grunt-clean');

  //var changeLog = grunt.file.read('../CHANGELOG.md');
  //grunt.log.writeln([changeLog]);

  grunt.initConfig({
    jshint: {
      options: {
        jshintrc: '.jshintrc'
      },
      sourceCode: ['wwwroot/app/**/*.js']
    },

    uglify: {
      dist: {
        files: {
          'dist/app/js/aritter.min.js': ['wwwroot/app/**/*.js']
        }
      }
    },

    cssmin: {
      dist: {
        files: {
          'dist/app/css/aritter.min.css': ['wwwroot/assets/css/**/*.css']
        }
      }
    },

    clean: {
      js: ['dist/app/js/**/*.js'],
      css: ['dist/app/css/**/*.css']
    }
  });

  grunt.registerTask('dist', ['uglify:dist', 'cssmin:dist']);

};
