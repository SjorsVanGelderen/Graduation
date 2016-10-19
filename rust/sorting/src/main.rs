/*
Sorting algorithms
Copyright 2016, Sjors van Gelderen
 */

//Import Ordering type
use std::cmp::Ordering;

/*
Insertion sort
Complexity: O(n^2)
 */
fn insertion_sort() {
    println!("Insertion sort:");
    
    let mut array = [5, 2, 4, 1, 3];
    
    for (index, key) in array.into_iter().enumerate() {
        if index == 0 {
            continue;
        }

        let element = &key;

        let mut iter_index = index;
        loop {
            if iter_index > 0 && element < array[iter_index - 1]{
                let temp = array[iter_index - 1];
                array[iter_index - 1] = element;
                array[iter_index] = temp;
                iter_index -= 1;
            } else {
                break;
            }
        }
    }

    for element in &array {
        println!("{}", element);
    }
}

fn main() {
    insertion_sort();
}
