
## Goals

The intent of this document is not to codify current practice at DevTeam as it stands at the time of writing. Instead, this guide has the following aims:

- To maximize readability and maintainability by prescribing a unified style.
- To maximize efficiency with logical, easy-to-understand and justifiable rules that balance code safety with ease-of-use.
- To maximize the usefulness of code-completion tools and accommodate IDE- or framework generated code.
- To prevent errors and bugs (especially hard-to-find ones) by minimizing complexity and applying proven design principles.
- To improve performance and reliability with a list of best practices.

Wherever possible, however, the guidelines include a specific justification for each design choice.

Unjustified guidelines must be either _justified_ or _removed_.

## Scope

This handbook mixes recommendations for programming with .NET, MVC, AngularJS, VUE Js. It includes rules for document layout (like whitespace and element placement) as well as design guidelines for elements and best practices for their use. It also assumes that you are using Microsoft Visual Studio 2017 or newer.

>This guide is a work-in-progress and covers only those issues that DevTeam has encountered and codifies only that which DevTeam has put into practice and with which DevTeam has experience.
>
>Therefore, some elements of style and design as well as some implicit best practices are probably not yet documented. _Speak up_ if you think there is something missing.
>
## Fixing Problems in the Guide

Unless otherwise noted, these guidelines **are not**** optional **, nor are they up to** interpretation**.

- If a guideline is not sufficiently clear, recommend a clearer formulation.
- If you don&#39;t like a guideline, try to get it changed or removed, but **don&#39;t just ignore** it.

## Fixing Problems in Code

If code is non-conforming, it should be fixed at the earliest opportunity.

- If the error is small and localized, you should fix it with the next check-in (noting during the code review that the change was purely stylistic and unrelated to other bug fixes).
- If the error is larger and/or involves renaming or moving files, you should check the change in separately in order to avoid confusion.
- If the problem takes too long to repair quickly, you should create an issue in the Team Foundation Server to address the problem at a later time.

#  When Does this Guide Apply

It is the intention that all code written for or by DevTeam adheres to this standard. However, there are some cases where it is impractical or impossible to apply these conventions.

This document applies to all code except the following:

## Code changes made to existing systems not written to this standard

In general, it is a good idea to make your changes conform to the surrounding code style wherever possible. You should choose to adopt this standard for major additions to existing systems or when you are adding code that you think will become part of the DevTeam code library.

## Code written for customers that require that their standards should be adopted

DevTeam may, from time to time work with customers that have their own coding standards. Most coding standards applicable to a Microsoft development language derive at least some of their content from a Microsoft white paper that documented a set of suggested naming standards. For this reason, many coding standards are broadly compatible with each other. This document goes a little further than most in some areas; however, it is likely that these extensions will not conflict with most other coding standards. We must be absolutely clear on this point: if there is a conflict, the customer&#39;s coding standards are to apply - always.