# Sass

Sass is a stylesheet language that’s compiled to CSS. It allows you to use variables, nested rules, mixins, functions, and more, all with a fully CSS-compatible syntax. Sass helps keep large stylesheets well-organized and makes it easy to share design within and across projects.

### Syntax

The SCSS syntax uses the file extension _.scss_. With a few small exceptions, it’s a superset of CSS, which means essentially all 
valid CSS is valid SCSS as well. Because of its similarity to CSS, it’s the easiest syntax to get used to and the most popular.

```
@mixin generateColorBorder($name, $color){
    .text-border__bottom--#{$name} {
        color: $color !important;
        border-bottom-color: $color !important;
    }
}

.data-name, .data-label{
  @extend .font-14;
  @extend .color-secondary-6;
}

.data{
  @extend .font-16;
  @extend .color-black;
  font-weight: normal;
}
```

### Structure

Just like CSS, most Sass stylesheets are mainly made up of style rules that contain property declarations. But Sass stylesheets have many more features that can exist alongside these.

#### Statements

* **Universal Statements**

These types of statements can be used anywhere in a Sass stylesheet:

- Variable declarations, like _$var: value_.
- Flow control at-rules, like _@if_ and _@each_.
- The _@error_, _@warn_, and _@debug_ rules.

* **CSS Statements**

These statements produce CSS. They can be used anywhere except within a @function:

- Style rules, like _h1 { /* ... */ }_.
- CSS at-rules, like _@media_ and _@font-face_.
- Mixin uses using _@include_.
- The _@at-root_ rule.

* **Top-Level Statements**

These statements can only be used at the top level of a stylesheet, or nested within a CSS statement at the top level:

- Module loads, using _@use_.
- Imports, using _@import_.
- Mixin definitions using _@mixin_.
- Function definitions using _@function_.

#### Our Project

In our project scss syntax is being used.  So, our sass files are .scss extentions.  This files are store in src/assets/scss in the folder where they should belong.

#### Import

```
@import "./colors";
@import "./layouts";
@import "./fonts";
@import "./backgrounds";
@import "./borders";
```

### References

The following references were used in the creation of this documentation:

- Sass Documentation
[https://sass-lang.com/documentation](https://sass-lang.com/documentation)

- Preprocesor Guide
[https://www.creativebloq.com/web-design/what-is-sass-111517618](https://www.creativebloq.com/web-design/what-is-sass-111517618)

