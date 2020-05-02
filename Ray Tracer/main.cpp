#include <cmath>
#include <iostream>
#include <string>

#include "Vector.h"
#include "Line.h"
#include "Geometry.h"
#include "Sphere.h"
#include "Image.h"
#include "Color.h"
#include "Intersection.h"
#include "Material.h"

#include "Scene.h"

using namespace std;
using namespace rt;

float imageToViewPlane(int n, int imgSize, float viewPlaneSize) {
	float u = (float)n * viewPlaneSize / (float)imgSize;
	u -= viewPlaneSize / 2;
	return u;
}

const Intersection findFirstIntersection(const Line& ray,
	float minDist, float maxDist) { // minDist = front plane; maxDist = back plane
	Intersection intersection;

	for (int i = 0; i < geometryCount; i++) {
		Intersection in = scene[i]->getIntersection(ray, minDist, maxDist);
		if (in.valid()) {
			if (!intersection.valid()) {
				intersection = in;
			}
			else if (in.t() < intersection.t()) {
				intersection = in;
			}
		}
	}

	return intersection;
}

int main() {
	Vector viewPoint(-50, 10, 0);
	Vector viewDirection(50, -10, 100);
	Vector viewUp(0, -1, 0);

	viewDirection.normalize();
	viewUp.normalize();

	float frontPlaneDist = 0;
	float backPlaneDist = 1000;

	float viewPlaneDist = 65;
	float viewPlaneWidth = 160;
	float viewPlaneHeight = 120;

	int imageWidth = 1024;
	int imageHeight = 768;

	Vector viewParallel = viewUp ^ viewDirection;
	viewParallel.normalize();

	Image image(imageWidth, imageHeight);

	Vector L; // light position vector
	Vector C = viewPoint; // camera position vector
	Vector V; // intersection position vector 
	Vector E; // vector from the intersection point to the camera
	Vector N; // normal to the surface at the intersection point
	Vector T; // vector from the intersection point to the light
	Vector R; // reflection vector

	// if the intersection is invalid - put black in the pixel
	// if the intersection is valid - put the color of the geometry object in the pixel

	for (int i = 0; i < imageWidth; i++) {
		for (int j = 0; j < imageHeight; j++) {
			Vector v = viewPoint +
				viewDirection * viewPlaneDist +
				viewUp * imageToViewPlane(j, imageHeight, viewPlaneHeight) +
				viewParallel * imageToViewPlane(i, imageWidth, viewPlaneWidth);
			Line line = Line(viewPoint, v, false);
			Intersection intersection = findFirstIntersection(line, frontPlaneDist, backPlaneDist);

			if (intersection.valid()) {

				Color color = intersection.geometry()->color();
				for (Light* light : lights) {
					L = light->position();
					V = intersection.vec();
					E = C - V;
					E.normalize();
					N = intersection.geometry()->normal(V);
					T = L - V;
					T.normalize();
					R = N * (N * T) * 2 - T;
					R.normalize();

					color += intersection.geometry()->material().ambient() * light->ambient();
					if (N * T > 0)
						color += intersection.geometry()->material().diffuse() * light->diffuse() * (N * T);
					if (E * R > 0)
						color += intersection.geometry()->material().specular() * light->specular() * pow(E * R, intersection.geometry()->material().shininess());
				}

				image.setPixel(i, j, color);
			}
			else {
				image.setPixel(i, j, Color(0, 0, 0));
			}
		}
	}

	image.store("scene.png");

	for (int i = 0; i < geometryCount; i++) {
		delete scene[i];
	}

	for (int i = 0; i < lightCount; i++) {
		delete lights[i];
	}

	return 0;
}