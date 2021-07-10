using Skypex.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Skypex.Raycasting
{
    public class Raycast2D
    {
        // Single Hit Raycasts
        public static RaycastHit2D Single(Vector2 origin, Vector2 direction) =>
            Physics2D.Raycast(origin, direction);

        public static RaycastHit2D Single(Vector2 origin, Vector2 direction, float distance) =>
            Physics2D.Raycast(origin, direction, distance);

        public static RaycastHit2D Single(Vector2 origin, Vector2 direction, float distance, int layerMask) =>
            Physics2D.Raycast(origin, direction, distance, layerMask);

        public static RaycastHit2D Single(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth) =>
            Physics2D.Raycast(origin, direction, distance, layerMask, minDepth);

        public static RaycastHit2D Single(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.Raycast(origin, direction, distance, layerMask, minDepth, maxDepth);

        public static int Single(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance) =>
            Physics2D.Raycast(origin, direction, contactFilter, results, distance);

        // Multi Hit Raycasts
        public static RaycastHit2D[] Multiple(Vector2 origin, Vector2 direction) =>
            Physics2D.RaycastAll(origin, direction);

        public static RaycastHit2D[] Multiple(Vector2 origin, Vector2 direction, float distance) =>
            Physics2D.RaycastAll(origin, direction, distance);

        public static RaycastHit2D[] Multiple(Vector2 origin, Vector2 direction, float distance, int layerMask) =>
            Physics2D.RaycastAll(origin, direction, distance, layerMask);

        public static RaycastHit2D[] Multiple(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth) =>
            Physics2D.RaycastAll(origin, direction, distance, layerMask, minDepth);

        public static RaycastHit2D[] Multiple(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.RaycastAll(origin, direction, distance, layerMask, minDepth, maxDepth);

        // Multi Ray Raycasts
        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, int numberOfRays, float width)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                hits.Add(Single(newOrigin, direction));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                hits.Add(Single(newOrigin, direction, distance));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                hits.Add(Single(newOrigin, direction, distance, layerMask));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, out Vector2[] origins)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            origins = new Vector2[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                origins[i] = newOrigin;
                hits.Add(Single(newOrigin, direction));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance, out Vector2[] origins)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            origins = new Vector2[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                origins[i] = newOrigin;
                hits.Add(Single(newOrigin, direction, distance));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance, int layerMask, out Vector2[] origins)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            origins = new Vector2[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                origins[i] = newOrigin;
                hits.Add(Single(newOrigin, direction, distance, layerMask));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, float angle, int numberOfRays)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            float halfAngle = angle / 2;
            float directionAngle = Vector2.SignedAngle(origin, direction) + 90f; // Find angle and reallign 0 direction.

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newDirection = ((directionAngle - halfAngle) + (angle / (numberOfRays - 1) * i)).DegreeToVector2();
                hits.Add(Single(origin, newDirection));
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, int numberOfRays, float angle, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");

            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();

            float halfAngle = angle / 2;

            float directionAngle = Vector2.SignedAngle(origin, origin + direction); // Find angle of the direction where 0 is downwards.
            directionAngle += 90f; // Allign 0 to the right because of a function i'm using later.
            Debug.Log("directionAngle = " + directionAngle);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            for (int i = 0; i < numberOfRays; i++)
            {
                // Calculate the new directions angled from the initial direction.
                // DegreeToVector2 is an extension method that turns an angle(degrees), where 0 is to the right, to a vector with magnitude 1. Have confirmed this to work as well.
                Vector2 newDirection = ((directionAngle - halfAngle) + (angle / (numberOfRays - 1) * i)).DegreeToVector2();
                Debug.Log("newDirection = " + newDirection);
                hits.Add(Single(origin, newDirection, distance, layerMask));
            }

            return hits.ToArray();
        }

        // Multi Ray Multi Hit Raycasts
        public static List<RaycastHit2D[]> MultiParallel(Vector2 origin, Vector2 direction, int numberOfRays, float width)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D[]> hits = new List<RaycastHit2D[]>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                hits.Add(Multiple(newOrigin, direction));
            }

            return hits;
        }

        public static List<RaycastHit2D[]> MultiParallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D[]> hits = new List<RaycastHit2D[]>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                hits.Add(Multiple(newOrigin, direction, distance));
            }

            return hits;
        }

        public static List<RaycastHit2D[]> MultiParallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D[]> hits = new List<RaycastHit2D[]>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                hits.Add(Multiple(newOrigin, direction, distance, layerMask));
            }

            return hits;
        }

        public static List<RaycastHit2D[]> MultiParallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, out Vector2[] origins)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D[]> hits = new List<RaycastHit2D[]>();
            origins = new Vector2[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                origins[i] = newOrigin;
                hits.Add(Multiple(newOrigin, direction));
            }

            return hits;
        }

        public static List<RaycastHit2D[]> MultiParallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance, out Vector2[] origins)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D[]> hits = new List<RaycastHit2D[]>();
            origins = new Vector2[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                origins[i] = newOrigin;
                hits.Add(Multiple(newOrigin, direction, distance));
            }

            return hits;
        }

        public static List<RaycastHit2D[]> MultiParallel(Vector2 origin, Vector2 direction, int numberOfRays, float width, float distance, int layerMask, out Vector2[] origins)
        {
            if (numberOfRays <= 0)
                throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
            if (numberOfRays == 1)
                Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

            direction.Normalize();
            Vector2 perpDirection = direction.Perp().SetMagnitude(width);
            Vector2 halfPerpDirection = perpDirection / 2;

            List<RaycastHit2D[]> hits = new List<RaycastHit2D[]>();
            origins = new Vector2[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                origins[i] = newOrigin;
                hits.Add(Multiple(newOrigin, direction, distance, layerMask));
            }

            return hits;
        }
    }

    public class Raycast
    {
        // Single Hit Raycasts
        public static bool Single(Ray ray) =>
            Physics.Raycast(ray);

        public static bool Single(Ray ray, float maxDistance) =>
            Physics.Raycast(ray, maxDistance);

        public static bool Single(Ray ray, float maxDistance, int layerMask) =>
            Physics.Raycast(ray, maxDistance, layerMask);

        public static bool Single(Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Raycast(ray, maxDistance, layerMask, queryTriggerInteraction);

        public static bool Single(Ray ray, out RaycastHit hitInfo) =>
            Physics.Raycast(ray, out hitInfo);

        public static bool Single(Ray ray, out RaycastHit hitInfo, float maxDistance) =>
            Physics.Raycast(ray, out hitInfo, maxDistance);

        public static bool Single(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask) =>
            Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);

        public static bool Single(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Raycast(ray, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);

        public static bool Single(Vector3 origin, Vector3 direction) =>
            Physics.Raycast(origin, direction);

        public static bool Single(Vector3 origin, Vector3 direction, float distance) =>
            Physics.Raycast(origin, direction, distance);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, int layerMask) =>
            Physics.Raycast(origin, direction, distance, layerMask);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Raycast(origin, direction, distance, layerMask, queryTriggerInteraction);

        public static bool Single(Vector3 origin, Vector3 direction, out RaycastHit hitInfo) =>
            Physics.Raycast(origin, direction, out hitInfo);

        public static bool Single(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float distance) =>
            Physics.Raycast(origin, direction, out hitInfo, distance);

        public static bool Single(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float distance, int layerMask) =>
            Physics.Raycast(origin, direction, out hitInfo, distance, layerMask);

        public static bool Single(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Raycast(origin, direction, out hitInfo, distance, layerMask, queryTriggerInteraction);

        // Multi Hit Raycasts
        public static RaycastHit[] All(Vector3 origin, Vector3 direction) =>
            Physics.RaycastAll(origin, direction);

        public static RaycastHit[] All(Vector3 origin, Vector3 direction, float distance) =>
            Physics.RaycastAll(origin, direction, distance);

        public static RaycastHit[] All(Vector3 origin, Vector3 direction, float distance, int layerMask) =>
            Physics.RaycastAll(origin, direction, distance, layerMask);

        public static RaycastHit[] All(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.RaycastAll(origin, direction, distance, layerMask, queryTriggerInteraction);

        public static RaycastHit[] All(Ray ray) =>
            Physics.RaycastAll(ray);

        public static RaycastHit[] All(Ray ray, float distance) =>
            Physics.RaycastAll(ray, distance);

        public static RaycastHit[] All(Ray ray, float distance, int layerMask) =>
            Physics.RaycastAll(ray, distance, layerMask);

        public static RaycastHit[] All(Ray ray, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.RaycastAll(ray, distance, layerMask, queryTriggerInteraction);

        // MultiRay Raycasts

        //public static RaycastHit[] RaycastRadial(Vector3 origin, Vector3 direction, Vector3 normal, int numberOfRays, float angle)
        //{
        //    //public static RaycastHit2D[] RaycastRadial(Vector2 origin, Vector2 direction, float angle, int numberOfRays)
        //    //{
        //    //    if (numberOfRays <= 0)
        //    //        throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
        //    //    if (numberOfRays == 1)
        //    //        Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

        //    //    direction.Normalize();
        //    //    float halfAngle = angle / 2;
        //    //    float directionAngle = Vector2.SignedAngle(origin, direction) + 90f; // Find angle and reallign 0 direction.

        //    //    List<RaycastHit2D> hits = new List<RaycastHit2D>();

        //    //    for (int i = 0; i < numberOfRays; i++)
        //    //    {
        //    //        Vector2 newDirection = ((directionAngle - halfAngle) + (angle / (numberOfRays - 1) * i)).DegreeToVector2();
        //    //        hits.Add(RaycastSingle(origin, newDirection));
        //    //    }

        //    //    return hits.ToArray();
        //    //}

        //    //if (numberOfRays <= 0)
        //    //    throw new System.ArgumentOutOfRangeException("Number of rays cannot be zero or negative.");
        //    //if (numberOfRays == 1)
        //    //    Debug.LogWarning("Using a method meant for casting multiple rays to only cast a single one, use RaycastSingle instead");

        //    //direction.Normalize();
        //    //float halfAngle = angle / 2;
        //    //float directionAngle = Vector2.SignedAngle(origin, direction) + 90f; // Find angle and reallign 0 direction.

        //    //List<RaycastHit2D> hits = new List<RaycastHit2D>();

        //    //for (int i = 0; i < numberOfRays; i++)
        //    //{
        //    //    Vector2 newDirection = ((directionAngle - halfAngle) + (angle / (numberOfRays - 1) * i)).DegreeToVector2();
        //    //    hits.Add(RaycastSingle(origin, newDirection));
        //    //}

        //    //return hits.ToArray();
        //}
    }

    public class DrawRays
    {
        public static void Ray2D(Vector2 origin, RaycastHit2D hit, float duration = .5f) =>
            Debug.DrawLine(origin, hit.point, Color.red, duration);

        public static void Rays2D(Vector2 origin, RaycastHit2D[] hits, float duration = .5f)
        {
            foreach (var hit in hits)
                Debug.DrawLine(origin, hit.point, Color.red, duration);
        }

        public static void Rays2D(Vector2[] origins, RaycastHit2D[] hits, float duration = .5f)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.DrawLine(origins[i], hits[i].point, Color.red, duration);
            }
        }

        public static void Ray(Vector3 origin, RaycastHit hit, float duration = .5f) =>
            Debug.DrawLine(origin, hit.point, Color.red, duration);

        public static void Rays(Vector3 origin, RaycastHit[] hits, float duration = .5f)
        {
            foreach (var hit in hits)
                Debug.DrawLine(origin, hit.point, Color.red, duration);
        }

        public static void Rays(Vector3[] origins, RaycastHit[] hits, float duration = .5f)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.DrawLine(origins[i], hits[i].point, Color.red, duration);
            }
        }

    }
}