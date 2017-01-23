/*
Guessing game
Copyright 2016, Sjors van Gelderen
 */

//Import random generation functionality
extern crate rand;

//Import Ordering type
use std::cmp::Ordering;

//Import Rng trait
use rand::Rng;

fn main() {    
    //Generate random number
    let secret_number = rand::thread_rng().gen_range(1, 101);
    let mut guess = String::new();
    
    //Main loop
    loop {
        println!("Guess the number!");
        println!("Please provide some input.");
        
        //Get input
        std::io::stdin().read_line(&mut guess)
            .expect("Failed to read line!");

        //Parse the input
        let guess: u32 = match guess.trim().parse() {
            Ok(num) => num,
            Err(_)  => continue
        };
        
        println!("You guessed: {}", guess);
        
        //Check the number
        match guess.cmp(&secret_number) {
            Ordering::Less    => println!("Too small!"),
            Ordering::Greater => println!("Too big!"),
            Ordering::Equal   => {
                println!("You win!");
                break;
            }
        }
    }
}
