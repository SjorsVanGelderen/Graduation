/*
Peak finding examples
Copyright 2016, Sjors van Gelderen
 */

/*
Simple linear peak finding
Sensitive to local optima
 */
fn find_peak_linear() {
    let array: [i32; 7] = [0, 5, 2, 5, 7, 8, 1];
    
    fn check_higher(index: usize, element: i32) -> bool {
        match array.get(index) {
            Some(x) => {
                if element > x {
                    return true;
                }
            },
            None => {
                println!("Error, this index is out of bounds!");
            }
        }
        
        return false;
    }
    
    println!("Linear peak finding:");
    
    for (index, element) in array.into_iter().enumerate() {
        if index == 0 {
            if check_higher(index + 1, element) {
                println!("Peak found at index: {}", index);
                break;
            }
        } else if index == array.len() - 1 {
            if check_higher(index - 1, element) {
                println!("Peak found at index: {}", index);
                break;
            }
        } else {
            if check_higher(index - 1, element) && check_higher(index + 1, element) {
                println!("Peak found at index: {}", index);
                break;
            }
        }
    }
}

fn find_peak_smart() {
    println!("Smart peak finding:");
}

fn main() {
    find_peak_linear();
    find_peak_smart();
}
