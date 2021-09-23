const sass = require('gulp-dart-sass')
const { src, dest } = require('gulp')
const sassLint = require('gulp-sass-lint')
const config = require('../gulp.config.json')
const autoprefixer = require('gulp-autoprefixer')
const cleanCSS = require('gulp-clean-css')
const rename = require('gulp-rename')

function scss () {
  return src(config.sass.source)
    .pipe(sass().on('error', sass.logError))
    .pipe(autoprefixer({
      cascade: false,
      grid: true
    }))
    .pipe(cleanCSS())
    .pipe(rename({ suffix: '.min' }))
    .pipe(dest(config.sass.destination))
}

function scssLint () {
  return src(config.sass.lint)
    .pipe(sassLint())
    .pipe(sassLint.format())
    .pipe(sassLint.failOnError())
}

module.exports = {
  scss,
  scssLint
}