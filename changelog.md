# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.5.1] - 2026-10-10
    
### Fixed
- Plot drawing for large data sets
- usage of AxisMargin & FLatStyle for Plot control

### Changed
- Removed DualZipBar


## [0.5.0] 2026-09-03

### Added
- highlight of selected TreeDetailsViewSubItem by MouseOver
- refreshing timer to TreeDetailsView


## [0.4.0] 2026-08-30

### Fixed
- changing column's width
- TreeListView in for Designer use
- unknown characters for LCDDisplay
- buttons in TreeDetailsView

### Changed
- renamed TreeListView to TreeDetailsView
- getItemSize from only first column, to max height of subitems

### Added
- horizontal scroll bar
- adders for Columns/Nodes/Subitems
- class for subitems instead of strings
- TimerResize for detecting ResizeEnd event
- RelatedObject logic for TreeDetailsViewSubItem
- functions to add subnodes in node
- Tag element (user purpose object) to TreeDetailsViewSubItem
- ItemMouseEnter & ItemMouseLeave to TreeDetailsView


## [0.3.0] 2026-08-20

### Fixed
- tree buttons & lines

### Added
- VisBox.PropertyEditor
- first version of TreeListView

### Changed
- VisBox.Plot


## [0.2.0] 2026-03-30

### Fixed
- ZipBar's Fixed2Nearby & drawing
- vertical ZipBar & added MouseWheel to it

### Added
- Class Diagram of VisBox library

### Changed
- to proper names of few variables/properties
- DemoGUI "Tester"


## [0.1.0] 2026-03-29

### Added
- First commit after 3 years of development
