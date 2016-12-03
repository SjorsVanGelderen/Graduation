#!/usr/bin/csi -s

#|
Linear search algorithm example
Complexity: O(n)
Copyright 2016, Sjors van Gelderen
|#

(define (linear-search collection target current)
  (if (eq? current 0)
      (print (conc "Searching for " target " in " collection)))
  (if (null? collection)
      (print "Element not in collection!")
      (if (= target (car collection))
	  (if (eq? current 1)
	      (print (conc "Found " target " after 1 try"))
	      (print (conc "Found " target " after " current " tries")))
	  (linear-search (cdr collection) target (+ current 1)))))

(print "Linear search example - Copyright 2016, Sjors van Gelderen")
(print)
(linear-search '(1 3 5 7 9 8 6 4 2) 4 0)
(linear-search '(1 3 5 7 9 8 6 4 2) 13 0)
(linear-search '(1 3 5 7 9 8 6 4 2) 3 0)
