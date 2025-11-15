# Cluster Growth Simulations: DLA & ECGM in C#

This repository presents interactive simulations of cluster growth using two classic models: **Diffusion-Limited Aggregation (DLA)** and the **Eden Cluster Growth Model (ECGM)**. Implemented in C#, these simulations illustrate how simple stochastic rules can produce complex patterns in two dimensions.

---

## 🔬 Project Details

### Random Walk and Perimeter Concept

Both DLA and ECGM rely on randomness to determine where new particles are added:

* **Random number generation** controls particle movement (DLA) or selection (ECGM).
* **Perimeter array** tracks neighboring empty sites for potential growth.
* **DLA:** Particles perform a random walk until they contact the cluster.
* **ECGM:** Particles are added directly to a randomly selected perimeter site.
* Randomness follows **pseudo-random sequences**, producing deterministic but unpredictable outcomes.

---

### Diffusion-Limited Aggregation (DLA)

* **Particle motion (random walk / diffusion):**

r_(t+1) = r_t + η_t

r_t = (x_t, y_t) is the particle position at step t
η_t = (η_x, η_y), random displacement vector, η_x, η_y ∈ {−1, +1} (or Uniform(−1,1))

* **Attachment condition:**
  If a particle contacts a cluster neighbor r_cluster, it attaches:
  r_t ∈ Cluster

* **Perimeter update (growth front):**
  Perimeter = { r ∈ Z² | r is neighbor of Cluster and not occupied }

* **Result:** Produces sparse, branched clusters with fractal-like structures.

---

### Eden Cluster Growth Model (ECGM)

* **Perimeter definition:**
  Perimeter = { r ∈ Z² | r is neighbor of Cluster and not occupied }

* **Growth rule:**
  r_new ∈ Perimeter, chosen uniformly at random

* **Cluster update:**
  Cluster = Cluster ∪ r_new

* **Result:** Produces dense, compact clusters with solid patterns.

---

### Key Differences

| Feature         | DLA                                                  | ECGM                                                   |
| --------------- | ---------------------------------------------------- | ------------------------------------------------------ |
| Particle motion | Random walk: r_(t+1) = r_t + η_t                     | None: particles added directly at perimeter            |
| Growth rule     | Attach when adjacent to cluster → fractal, branching | Uniform random selection on perimeter → dense, compact |

---

## 🧪 Observations & Results

* **DLA clusters:** Sparse, branched structures reminiscent of natural fractals.
* **ECGM clusters:** Dense, solid growth patterns.
* **Randomness:** Each cluster is unique but can be reproduced using a fixed seed.
* **Visualization:** Confirms expected growth rules: fractal vs dense patterns.

---

## ✅ Conclusion

This simulation demonstrates:

* How **randomness drives cluster growth** in DLA and ECGM.
* How **growth rules impact structure:** branching vs dense.
* The power of **stochastic modeling** to understand complex natural and biological phenomena.
* How **deterministic pseudo-random number generators** can reproduce results for testing and visualization.

By combining **random number generation**, **perimeter tracking**, and **iterative growth**, this program provides a clear example of **emergent complexity from simple rules** in computational simulations.

---

## ⚙️ Numerical Techniques Used

* Random Walk Simulation (DLA)
* Perimeter Tracking (DLA & ECGM)
* Pseudo-Random Number Generation
* Iterative Cluster Growth Rules

---

## 🧮 Technologies

* **Language:** C#
* **Framework:** .NET (Windows Forms)
* **Graphics:** GDI+ (System.Drawing)
* **Environment:** Visual Studio

---

## 🧠 Educational Purpose

These simulations help learners:

* Visualize stochastic cluster growth
* Understand fractal vs compact structures
* Study emergent patterns from simple rules
* Explore applications in material science, physics, and biology

---

## 🔗 Website Reference

Detailed write-ups and visual demonstrations: [Fatima Ijaz C# Projects](https://sites.google.com/view/fatima-ijaz/c-projects)

---

## 📜 Author

**Fatima Ijaz**
BS in Computational Physics — University of the Punjab
Focused on Computational Physics and Scientific Simulations
Certified: 100 Days of Code – The Complete Python Pro Bootcamp by Dr. Angela Yu
