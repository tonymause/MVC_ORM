'use strict'

var gulp = require('gulp');
var clean = require('gulp-clean');


var bases = {
  app: 'app/',
  dest_n: 'NHibernateMVC/lib/',
  dest_e: 'EntityFrameworkMVC/lib/'
}

// clean
gulp.task('clean', function(){
  return gulp.src([bases.dest_n, bases.dest_e])
    .pipe(clean());
});

gulp.task('copy', ['clean'], function(){
  return gulp.src(['node_modules/jquery/**/*', 'node_modules/bootstrap/**/*'],
                  {base:'node_modules'})
          .pipe(gulp.dest(bases.dest_n))
          .pipe(gulp.dest(bases.dest_e));
});

gulp.task('default', ['clean', 'copy']);
