#!/usr/bin/csi -s

#|
Binary search algorithm example
Complexity: O(n log n)
Copyright 2016, Sjors van Gelderen
|#

#|
(define (binary-search collection target)
  (
  ))

(define (linear-search collection target current)
  (if (null? collection)
      (print "Element not in collection!")
      ((if (= target (car collection))
	   (print (conc "Found " target " after " current " tries"))
	   (linear-search (cdr collection) target (+ current 1)))))

(print "Linear search example - Copyright 2016, Sjors van Gelderen")
(print)
(linear-search '(1 3 5 7 9 8 6 4 2) 4 0)
#|
