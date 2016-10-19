/*
Search algorithms
Copyright 2016, Sjors van Gelderen
 */

//Import Ordering type
use std::cmp::Ordering;

/*
Linear search algorithm
Complexity: O(n)
 */
fn linear_search(_target: i32) {
    let array = [0, 1, 2, 3, 4, 5, 6, 7];

    println!("Linear search for {}:", _target);

    for (index, element) in array.into_iter().enumerate() {
        if element == &_target {
            println!("Found target at index: {}!", index);
            return;
        } else {
            println!("Touching index: {}", index);
        }
    }

    println!("Could not find target!");
}

/*
Binary search algorithm
Complexity: O(log n)
 */
fn binary_search(_target: i32) {
    let array = [0, 1, 2, 3, 4, 5, 6, 7];
    let mut pivot = array.len() / 2;
    
    println!("Binary search for {}:", _target);
    
    loop {
        let old_pivot = pivot;
        
        match array.get(pivot) {
            Some(x) => {
                match x.cmp(&_target) {
                    Ordering::Less => {
                        println!("Touching index: {}", pivot);
                        pivot = (array.len() - pivot) / 2 + pivot;
                    },
                    Ordering::Greater => {
                        println!("Touching index: {}", pivot);
                        pivot /= 2;
                    },
                    Ordering::Equal => {
                        println!("Found target at index: {}!", pivot);
                        return;
                    }
                }

                if pivot == old_pivot {
                    println!("Could not find target!");
                    return;
                }
            },
            None => {
                println!("Error, this pivot is out of bounds!");
                return;
            }
        }
    }
}

fn main() {
    linear_search(0);
    linear_search(5);
    linear_search(1200);
    
    binary_search(1);
    binary_search(4);
    binary_search(6);
    binary_search(7);
    binary_search(1100);
}
