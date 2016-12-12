#!/usr/bin/csi -s

#|
Insertion sort algorithm example
Complexity: O(n^2)
Copyright 2016, Sjors van Gelderen
|#

#|
(define (insertion-sort collection)
  (if

(define (linear-search collection element current)
  (if (= element (car collection))
      (print (conc "Found " element " after " current " tries"))
      (linear-search (cdr collection) element (+ current 1))))

(print "Linear search example - Copyright 2016, Sjors van Gelderen")
(print)
(linear-search '(1 3 5 7 9 8 6 4 2) 4 0)
|#