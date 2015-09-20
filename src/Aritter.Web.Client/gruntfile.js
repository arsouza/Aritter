module.exports = function (grunt) {

  require('load-grunt-tasks')(grunt);
  grunt.loadNpmTasks('grunt-contrib-clean');

  var project = grunt.file.readJSON('./project.json');

  var paths = {
    webroot: project.webroot + "/"
  };

  paths.js = paths.webroot + "app/**/*.js";
  paths.minJs = paths.webroot + "app/**/*.min.js";
  paths.css = paths.webroot + "assets/css/**/*.css";
  paths.minCss = paths.webroot + "assets/css/**/*.min.css";
  paths.concatJsDest = paths.webroot + "app/aritter.min.js";
  paths.concatCssDest = paths.webroot + "assets/css/aritter.min.css";

  grunt.initConfig({
    jshint: {
      options: {
        jshintrc: '.jshintrc'
      },
      app: [paths.js, '!' + paths.minJs]
    },
    clean: {
      build: {
        src: [paths.concatJsDest, paths.concatCssDest]
      }
    }
  });
};
