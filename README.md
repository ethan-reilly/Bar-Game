# **BAR SIMULATOR:**
### *WORK IN A BAR*



In "Bar Simulator" you'll find yourself working behind the bar and serving customers. 
This was a small project I made in 3 weeks to experiment with Unity and to use in a portfolio.
Any feedback is greatly appreciated!!



## *Controls:*

WASD to move

E to interact with NPCs, glasses and bottles

Q to pour drinks from tap

Right mouse to drop item



[Itch.io Page](https://cold-code-games.itch.io/bar-sim)


## *Code Walkthrough:*
Using Raycasts, we detect if the player is looking at something that can be picked up (a glass or a bottle). If the player is holding an empty glass and looking at a bar tap, the tap will highlight and they can fill the glass:

```
if (Physics.Raycast(playerCameraTransform.position,
           playerCameraTransform.forward,
           out hit2,
           hitRange,
           tapLayerMask) && inHandItem.CompareTag("Glass"))
            {
                //Debug.Log("Tap");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pourUI.SetActive(true);

                if (inHandItem.CompareTag("Glass") && Input.GetKeyDown(KeyCode.Q))
                //if (inHandItem == inHandItem.GetComponent<Glass>() && Input.GetKeyDown(KeyCode.Q))
                {
                    inHandItem.GetComponent<Glass>().FillGlass();
                }
                
            }
```

------------------------------

The NPCs had different responses based on the players current conditions. If the player had the wrong drink or an empty hand, the NPC would continue to ask for the right drink (which was randomly selected at runtime). 
```
Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
               if(collider.TryGetComponent(out NPC npc))
                {
                    // Debug.Log("Interacting with NPC.");

                    if (playerPickUp.inHandItem == null)
                    {
                        npc.Interact(0);
                    }
                    // If player has glass:
                    else if (playerPickUp.inHandItem.CompareTag("Glass"))
                    {
                        if (playerPickUp.inHandItem.TryGetComponent(out Glass glass))
                        {
                            // Check if glass is filled
                            if (glass.GetFilled())
                            {
                                if(npc.WantsPint() & !npc.GetDrink())
                                {
                                    npc.Interact(1, playerPickUp.inHandItem);
                                  
                                    playerPickUp.inHandItem = null;
                                }
                                else 
                                {
                                    npc.Interact(1, playerPickUp.inHandItem);
                                }
                            }
                            else
                            {
                                npc.Interact(0, playerPickUp.inHandItem);
                            }
                        }
                    }
                    else if (playerPickUp.inHandItem.CompareTag("Bottle"))
                    {
                        if (npc.WantsBottle() & !npc.GetDrink())
                        {
                            npc.Interact(2, playerPickUp.inHandItem);
                            playerPickUp.inHandItem = null;
                        }

                        if (npc.WantsPint() & !npc.GetDrink())
                        {
                            npc.Interact(2, playerPickUp.inHandItem);
                        }
                    }
                
                }
                    
            }
        }
```

## *Things I wanted to add:*
If I was going to continue this project further, I would like to:
- Add more drink types
- Research liquid physics so the drinks would actually pour
- Improve animations
- Right now, it's more of a sandbox/demo so it needs win/lose requirements
